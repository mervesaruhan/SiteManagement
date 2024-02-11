namespace SiteManagement.Models.AparmentInfos
{
    public interface IApartmentRepository
    {
        void AddApartment(Apartment apartment);
        List<Apartment> GetAllApartments();
        Apartment GetApartmentByNumber(int number);
        void UpdateApartment(Apartment apartment);
        void DeleteApartment(int aparmentNumber);
        List<Apartment> GetApartmentsWithUsers();
    }
}
