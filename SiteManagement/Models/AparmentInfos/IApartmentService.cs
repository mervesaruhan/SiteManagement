namespace SiteManagement.Models.AparmentInfos
{
    public interface IApartmentService
    {
        void AddApartment(Apartment apartment);
        List<Apartment> GetAllApartments();
        Apartment GetApartmentByNumber(int number);
        void UpdateApartment(int apartmentNumber, Apartment updatedApartment);
        void DeleteApartment(int id);
    }
}
