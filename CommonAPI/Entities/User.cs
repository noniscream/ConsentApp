namespace CommonAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PwdHash { get; set; }
        public byte[] PwsSalt { get; set; }
    }
}