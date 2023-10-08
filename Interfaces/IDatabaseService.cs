using System.Data;

namespace TaskGateX.Interfaces
{
    interface IDatabaseService
    {
        DataTable GetUserData();
        int UpdateUser(int userID, string firstName, string lastName, string email);
        int DeleteUser(int userID);
        int RegisterUser(string firstName, string lastName, string email, string password);
    }
}
