using Hospital_Management.Controllers;

namespace Hospital_Management.Helpers
{
    /// <summary>
    /// Helper class for role-based access control
    /// </summary>
    public static class RoleHelper
    {
        // Role constants
        public const string ROLE_ADMIN = "admin";
        public const string ROLE_DOCTOR = "doctor";
        public const string ROLE_NURSE = "nurse";
        public const string ROLE_STAFF = "staff";

        /// <summary>
        /// Check if current user is Admin
        /// </summary>
        public static bool IsAdmin()
        {
            return CurrentUser.Role?.ToLower() == ROLE_ADMIN;
        }

        /// <summary>
        /// Check if current user is Doctor
        /// </summary>
        public static bool IsDoctor()
        {
            return CurrentUser.Role?.ToLower() == ROLE_DOCTOR;
        }

        /// <summary>
        /// Check if current user is Nurse
        /// </summary>
        public static bool IsNurse()
        {
            return CurrentUser.Role?.ToLower() == ROLE_NURSE;
        }

        /// <summary>
        /// Check if current user is Staff
        /// </summary>
        public static bool IsStaff()
        {
            return CurrentUser.Role?.ToLower() == ROLE_STAFF;
        }

        /// <summary>
        /// Check if user can access a specific menu
        /// </summary>
        public static bool CanAccessMenu(string menuName)
        {
            string role = CurrentUser.Role?.ToLower() ?? "";

            switch (menuName.ToLower())
            {
                case "home":
                    // Everyone can access Home
                    return true;

                case "staff":
                    // Admin and Doctor can access Staff
                    return role == ROLE_ADMIN || role == ROLE_DOCTOR;

                case "patients":
                    // Everyone can access Patients
                    return true;

                case "laboratory":
                    // Admin, Doctor, and Nurse can access Laboratory
                    return role == ROLE_ADMIN || role == ROLE_DOCTOR || role == ROLE_NURSE;

                case "capital":
                    // Only Admin can access Capital/Finance
                    return role == ROLE_ADMIN;

                case "units":
                    // Only Admin can access Units
                    return role == ROLE_ADMIN;

                case "appointments":
                    // Admin and Doctor can access Appointments
                    return role == ROLE_ADMIN || role == ROLE_DOCTOR;

                default:
                    return false;
            }
        }

        /// <summary>
        /// Check if user can perform edit operations
        /// </summary>
        public static bool CanEdit(string category)
        {
            string role = CurrentUser.Role?.ToLower() ?? "";

            switch (category.ToLower())
            {
                case "staff":
                    return role == ROLE_ADMIN;

                case "patients":
                    return role == ROLE_ADMIN || role == ROLE_DOCTOR || role == ROLE_NURSE;

                case "laboratory":
                    return role == ROLE_ADMIN || role == ROLE_DOCTOR;

                case "capital":
                    return role == ROLE_ADMIN;

                case "units":
                    return role == ROLE_ADMIN;

                default:
                    return role == ROLE_ADMIN;
            }
        }

        /// <summary>
        /// Check if user can perform delete operations
        /// </summary>
        public static bool CanDelete(string category)
        {
            // Only admin can delete
            return IsAdmin();
        }

        /// <summary>
        /// Get display name for current role
        /// </summary>
        public static string GetRoleDisplayName()
        {
            string role = CurrentUser.Role?.ToLower() ?? "";

            switch (role)
            {
                case ROLE_ADMIN: return "Administrator";
                case ROLE_DOCTOR: return "Doctor";
                case ROLE_NURSE: return "Nurse";
                case ROLE_STAFF: return "Staff";
                default: return "User";
            }
        }
    }
}
