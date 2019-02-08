using System;

namespace Epam.Task11_12.UsersAndAwards.Entities
{
    public class Award : IEquatable<Award>
    {
        public int AwardId { get; set; }

        public string AwardTitle { get; set; }

        public int AwardImageId { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Award);
        }

        public bool Equals(Award award)
        {
            if (ReferenceEquals(award, null))
            {
                return false;
            }

            if (ReferenceEquals(this, award))
            {
                return true;
            }

            if (this.GetType() != award.GetType())
            {
                return false;
            }

            return (this.AwardId == award.AwardId) && (this.AwardTitle == award.AwardTitle);
        }

        public override int GetHashCode()
        {
            int num = 5381;
            int num2 = num;
            num = num ^ this.AwardId;
            num2 = this.AwardTitle.GetHashCode();

            return num + (num2 * 1566083941);
        }

        public static bool operator ==(Award lhs, Award rhs)
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

        public static bool operator !=(Award lhs, Award rhs)
        {
            return !(lhs == rhs);
        }
    }
}
