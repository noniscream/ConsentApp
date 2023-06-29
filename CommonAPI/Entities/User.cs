using CommonAPI.Extensions;

namespace CommonAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PwdHash { get; set; }
        public byte[] PwsSalt { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string KnowAs { get; set; }
        public DateTime Created { get; set; }=DateTime.UtcNow;
        public DateTime LastActive { get; set; }=DateTime.UtcNow;
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Photo> Photos { get; set; } = new ();

        // public int GetAge(){
        //     return DateOfBirth.CalcuateAge();
        // }
    }
}