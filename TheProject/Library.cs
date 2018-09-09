using System.Collections.Generic;

namespace TheProject
{
    public class Library
    {
        private readonly Dictionary<string,Member> members = new Dictionary<string, Member>();

        public void AddMember(Member mikki)
        {
            members[mikki.Username] = mikki;
        }

        public void Login(string username, string password)
        {
            var member = members[username];
            member.IsLoggedIn = member.Password.Equals(password);
        }
    }
}