using System;

namespace Epam.Task7.UsersAndAwards.Entities
{
    public class AwardUser : IEquatable<AwardUser>
    {
        public int UserId { get; set; }

        public int AwardId { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as AwardUser);
        }

        public bool Equals(AwardUser au)
        {
            if (ReferenceEquals(au, null))
            {
                return false;
            }

            if (ReferenceEquals(this, au))
            {
                return true;
            }

            if (this.GetType() != au.GetType())
            {
                return false;
            }

            return (this.UserId == au.UserId) && (this.AwardId == au.AwardId);
        }

        public override int GetHashCode()
        {
            int num = 5381;
            int num2 = num;
            num = ((num << 5) + num) ^ this.UserId;
            num2 = ((num2 << 5) + num2) ^ this.AwardId;

            return num + (num2 * 1566083941);
        }

        public static bool operator ==(AwardUser lhs, AwardUser rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                if (ReferenceEquals(rhs, null))
                {
                    return true;
                }

                return false;
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(AwardUser lhs, AwardUser rhs)
        {
            return !(lhs == rhs);
        }
    }
}
