using OrderClasses.DataTransfer;

namespace OrderClasses.Converters
{
    public class PerformerConverter
    {
        public static PerformerDTO ToDTO(Performer performer)
        {
            return new PerformerDTO
            {
                FirstName = performer.FirstName,
                LastName = performer.LastName,
                DateOfBirth = performer.DateOfBirth
            };
        }
        public static Performer FromDTO(PerformerDTO dtoObj) => new Performer(dtoObj.FirstName, dtoObj.LastName, dtoObj.DateOfBirth);
    }
}
