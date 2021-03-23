using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClarkCodingChallenge.Models {
    public class ProfilesRepository : IProfilesRepository {
        private IEnumerable<Profile> _profiles;

        public ProfilesRepository() {
            _profiles = new List<Profile>();
            }
        public IEnumerable<Profile> Profiles {
            get { return _profiles; }
            set { _profiles = value; }
            }

        public IEnumerable<Profile> GetProfiles() {
            return _profiles.ToList();
            }
        public ProfileValidation AddProfile(string firstName, string lastName, string email) {
            Profile newProfile = new Profile {
                FirstName = firstName,
                LastName = lastName,
                Email = email
                };

            ProfileValidation returnValue = ValidateProfile(newProfile);
            if (returnValue != ProfileValidation.Valid) {
                return returnValue;
                }
            _profiles.Append(newProfile);
            return ProfileValidation.Valid;

            }

        public ProfileValidation ValidateProfile(Profile profile) {
            if (profile.FirstName == "" || profile.FirstName is null) {
                return ProfileValidation.InvalidFirstName;
                }
            if (profile.LastName == "" || profile.LastName is null) {
                return ProfileValidation.InvalidLastName;
                }
            if (profile.Email == "" || profile.Email is null) {
                return ProfileValidation.InvalidEmail;
                }
            try {
                var addr = new System.Net.Mail.MailAddress(profile.Email);
                if (addr.Address != profile.Email) {
                    return ProfileValidation.InvalidEmail;
                    }
                }
            catch {
                return ProfileValidation.InvalidEmail;
                }

            if (_profiles.Contains(profile)) {
                return ProfileValidation.ProfileExists;
                }
            return ProfileValidation.Valid;
            }


        }
    }
public enum ProfileValidation {
    InvalidFirstName,
    InvalidLastName,
    InvalidEmail,
    ProfileExists,
    Valid
    }

