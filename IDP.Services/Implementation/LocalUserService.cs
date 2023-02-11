namespace IDP.Services.Implementation
{
    using System.Security.Claims;
    using System.Security.Cryptography;

    using Microsoft.AspNetCore.Identity;

    using IDP.Domain.Entities;
    using IDP.Services.Interfaces;
    using IDP.Repository.Interfaces;
    using IDP.Common.Contracts.IUnitOfWork;

    public class LocalUserService : ILocalUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IUserLoginsRepository _userLoginsRepository;

        public LocalUserService(
            IUnitOfWork unitOfWork,
            IPasswordHasher<User> passwordHasher,
            IUserRepository userRepository,
            IUserLoginsRepository userLoginsRepository)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _userLoginsRepository = userLoginsRepository;
        }

        public async Task<User> FindUserByExternalProviderAsync(
            string provider, string providerIdentityKey)
        {
            if (string.IsNullOrWhiteSpace(provider))
            {
                throw new ArgumentNullException(nameof(provider));
            }

            if (string.IsNullOrWhiteSpace(providerIdentityKey))
            {
                throw new ArgumentNullException(nameof(providerIdentityKey));
            }

            //var userLogin = await _context.UserLogins.Include(ul => ul.User)
            //   .FirstOrDefaultAsync(ul => ul.Provider == provider
            //   && ul.ProviderIdentityKey == providerIdentityKey);

            UserLogin? userLogin = await _userLoginsRepository.FindUserByExternalProviderAsync(
                provider: provider,
                providerIdentityKey: providerIdentityKey);

            if(userLogin == null)
            {
                throw new ArgumentNullException(nameof(userLogin));

            }

            return userLogin.User;
        }

        public async Task<User> AutoProvisionUser(string provider,
            string providerIdentityKey,
            IEnumerable<Claim> claims)
        {
            if (string.IsNullOrWhiteSpace(provider))
            {
                throw new ArgumentNullException(nameof(provider));
            }

            if (string.IsNullOrWhiteSpace(providerIdentityKey))
            {
                throw new ArgumentNullException(nameof(providerIdentityKey));
            }

            if (claims is null)
            {
                throw new ArgumentNullException(nameof(claims));
            }

            var user = new User()
            {
                CreatedOn= DateTime.UtcNow,
                Active = true,
                Subject = Guid.NewGuid().ToString()
            };
            foreach (Claim claim in claims)
            {
                user.Claims.Add(new UserClaim()
                {
                    CreatedOn = DateTime.UtcNow,
                    Type = claim.Type,
                    Value = claim.Value
                });
            }
            user.Logins.Add(new UserLogin()
            {
                CreatedOn = DateTime.UtcNow,
                Provider = provider,
                ProviderIdentityKey = providerIdentityKey
            });

            //_context.Users.Add(user);
            //user repo add user
            await _userRepository.AddAsync(user);

            //_userRepository.SaveChangesAsync();

            await _unitOfWork.SaveChangesAsync();

            return user;
        }

        public async Task<bool> IsUserActive(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                return false;
            }

            var user = await GetUserBySubjectAsync(subject);

            if (user == null)
            {
                return false;
            }

            return user.Active;
        }

        public async Task<bool> ValidateCredentialsAsync(string userName,
          string password)
        {
            if (string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            User user = await GetUserByUserNameAsync(userName);

            if (user == null)
            {
                return false;
            }

            //if (!user.Active)
            //{
            //    return false;
            //}

            // Validate credentials
            // return (user.Password == password);
            var verificationResult =
                _passwordHasher.VerifyHashedPassword(
                    user, user.Password, password);
            return (verificationResult == PasswordVerificationResult.Success);

        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            User? user = await _userRepository.GetUserByUserNameAsync(userName);

            if(user == null)
            {
                throw new InvalidOperationException("User does not exist");
            }

            return user;
        }

        public async Task<IEnumerable<UserClaim>> GetUserClaimsBySubjectAsync(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentNullException(nameof(subject));
            }

            //return await _context.UserClaims.Where(u =>
            //    u.User.Subject == subject).ToListAsync();

            IEnumerable<UserClaim> userClaims = await _userRepository.GetUserClaimsBySubjectAsync(subject);

            return userClaims;
        }

        public async Task<User> GetUserBySubjectAsync(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentNullException(nameof(subject));
            }

            User? user =  await _userRepository.GetUserBySubjectAsync(subject);

            if(user == null)
            {
                throw new InvalidOperationException("User does not exist");
            }

            return user;
        }

        public async Task AddUser(User userToAdd, string password)
        {
            if (userToAdd == null)
            {
                throw new ArgumentNullException(nameof(userToAdd));
            }

            bool isUserNameUnique = await _userRepository.IsUserUserNameUniqueAsync(userToAdd.UserName);

            if (!isUserNameUnique)
            {
                // in a real-life scenario you'll probably want to 
                // return this as a validation issue
                throw new Exception("Username must be unique");
            }

            bool isUserEmailUnique = await _userRepository.IsUserEmailUniqueAsync(userToAdd.Email);

            if (!isUserEmailUnique)
            {
                throw new Exception("Email must be unique");
            }

            userToAdd.SecurityCode = Convert.ToBase64String(
                RandomNumberGenerator.GetBytes(128));
            userToAdd.SecurityCodeExpirationDate = DateTime.UtcNow.AddHours(1);

            // hash & salt the password
            userToAdd.Password =
                _passwordHasher.HashPassword(userToAdd, password);

            //_context.Users.Add(userToAdd);

            await _userRepository.AddAsync(userToAdd);

            //await _userRepository.SaveChangesAsync();
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> ActivateUserAsync(string securityCode)
        {
            if (string.IsNullOrWhiteSpace(securityCode))
            {
                throw new ArgumentNullException(nameof(securityCode));
            }

            // find an user with this security code as an active security code.  
            //var user = await _context.Users.FirstOrDefaultAsync(u =>
            //    u.SecurityCode == securityCode &&
            //    u.SecurityCodeExpirationDate >= DateTime.UtcNow);

            User? user = await _userRepository.FindUserByActiveSecurityCode
                (securityCode: securityCode,
                dateTime: DateTime.UtcNow);

            if (user == null)
            {
                return false;
            }

            user.Active = true;
            user.SecurityCode = null;

            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        //public async Task<bool> SaveChangesAsync()
        //{
        //    return (await _context.SaveChangesAsync() > 0);
        //}

        public async Task<bool> AddUserSecret(string subject,
            string name, string secret)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentNullException(nameof(subject));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrWhiteSpace(secret))
            {
                throw new ArgumentNullException(nameof(secret));
            }

            var user = await GetUserBySubjectAsync(subject);

            if (user == null)
            {
                return false;
            }

            user.Secrets.Add(new UserSecret()
            { Name = name, Secret = secret });

            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        //public async Task<UserSecret> GetUserSecretAsync(
        //    string subject, string name)
        //{
        //    if (string.IsNullOrWhiteSpace(subject))
        //    {
        //        throw new ArgumentNullException(nameof(subject));
        //    }

        //    if (string.IsNullOrWhiteSpace(name))
        //    {
        //        throw new ArgumentNullException(nameof(name));
        //    }

        //    return await _context.UserSecrets
        //        .FirstOrDefaultAsync(u => u.User.Subject == subject && u.Name == name);
        //}
    }
}
