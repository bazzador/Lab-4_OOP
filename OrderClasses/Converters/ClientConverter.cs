using OrderClasses.DataTransfer;

namespace OrderClasses.Converters
{
    public class ClientConverter
    {
        public static ClientDTO ToDTO(Client client)
        {
            return new ClientDTO
            {
                ServiceType = client.ServiceType_,
                Address = client.Address
            };
        }
        public static Client FromDTO(ClientDTO dtoObj) => new Client(dtoObj.ServiceType, dtoObj.Address);
    }
}
