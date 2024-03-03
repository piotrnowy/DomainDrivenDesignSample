using UserManagement.Domain.User.UpdateParameters;

namespace UserManagement.Domain.User
{
    public class User
    {
        private User(Guid id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public static User Reconstruct(Guid id, string firstName, string lastName, string email)
        {
            return new User(id, firstName, lastName, email);
        }

        public static User Create(string firstName, string lastName, string email)
        {
            return new User(Guid.NewGuid(), firstName, lastName, email);
        }

        public void UpdateEmail(UpdateEmailDto parameters)
        {
            this.Email = parameters.Email;
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; internal set; }
    }
}
