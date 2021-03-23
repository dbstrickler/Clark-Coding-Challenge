using System.Collections.Generic;

namespace ClarkCodingChallenge.Models {
    public interface IProfilesRepository {
        IEnumerable<Profile> Profiles { get; set; }

        ProfileValidation AddProfile(string firstName, string lastName, string email);
        IEnumerable<Profile> GetProfiles();
        ProfileValidation ValidateProfile(Profile profile);
        }
    }