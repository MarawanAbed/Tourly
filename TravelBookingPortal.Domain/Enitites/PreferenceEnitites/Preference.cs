
using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Domain.Enitites.PreferenceEnitites
{
    public class Preference
    {
        public int PreferenceId { get; set; }
        public string UserId { get; set; }
        public string PreferenceType { get; set; }
        public string PreferenceValue { get; set; }

        public ApplicationUser User { get; set; }
    }
}
