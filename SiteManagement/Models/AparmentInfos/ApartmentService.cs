using System.Drawing;

namespace SiteManagement.Models.AparmentInfos
{
    public class ApartmentService:IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;

        public ApartmentService(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }

        public void AddApartment(Apartment apartment)
        {
            var newApartment = new Apartment
            {
                BlockInfo = apartment.BlockInfo,
                IsOccupied = apartment.IsOccupied,
                Type = apartment.Type,
                Floor = apartment.Floor,
                ApartmentNumber = apartment.ApartmentNumber,
                OwnerOrTenant = apartment.OwnerOrTenant,

            };
            _apartmentRepository.AddApartment(apartment);
        }


        public List<Apartment> GetAllApartments()
        {
            return _apartmentRepository.GetAllApartments();
        }


        public Apartment GetApartmentByNumber(int number)
        {
            return _apartmentRepository.GetApartmentByNumber(number);
        }


        public void UpdateApartment(int apartmentNumber, Apartment updatedApartment)
        {
           
            var existingApartment = _apartmentRepository.GetApartmentByNumber(apartmentNumber);

            if (existingApartment == null)
            {
                throw new Exception("Apartman bulunamadı");
            }

            // Apartman bilgilerinin güncellenmesi
            existingApartment.BlockInfo = updatedApartment.BlockInfo;
            existingApartment.Floor = updatedApartment.Floor;
            existingApartment.BlockInfo = updatedApartment.BlockInfo;
            existingApartment.IsOccupied = updatedApartment.IsOccupied;
            existingApartment.Type = updatedApartment.Type;
            existingApartment.Floor = updatedApartment.Floor;
            existingApartment.ApartmentNumber = updatedApartment.ApartmentNumber;
            existingApartment.OwnerOrTenant = updatedApartment.OwnerOrTenant;

            // Güncellenmiş apartmanı repository üzerinden kaydetme işlemi
            _apartmentRepository.UpdateApartment(existingApartment);
        }


        public void DeleteApartment(int id)
        {
            _apartmentRepository.DeleteApartment(id);
        }
    }
}
