namespace CupAPI.Application.Common.Constants;

public static class Messages
{
    public static class General
    {
        public const string UnexpectedErrorOccurred = "Beklenmeyen bir hata oluştu. Lütfen daha sonra tekrar deneyin."; // (500 - Internal Server Error)
        public const string DataNotFound = "Kayıt bulunamadı."; // Veri Bulunamadı (404 - NotFound)
        public const string ValidatorNotFound = "Validator bulunamadı."; // Validasyon Hataları (422)
        public const string InvalidParameter = "Geçersiz parametre gönderildi."; // Validation (400)
        public const string OperationSuccessful = "İşlem başarılı."; // None (200)
        public const string DataIsEmpty = "Veri mevcut ancak boş."; // Veri boş (200 - Empty List)
    }

    public static class Auth
    {
        public const string EmailCannotBeEmpty = "Email adresi boş olamaz";
        public const string TokenGenerationFailed = "Token üretimi sırasında bir güvenlik hatası oluştu.";
        public const string TokenCreated = "Token başarıyla üretildi";
    }

    public static class Category
    {
        public const string NotFound = "Kategori başarıyla bulunamadı";
        public const string Created = "Kategori başarıyla oluşturuldu";
        public const string Updated = "Kategori başarıyla güncellendi";
        public const string Deleted = "Kategori başarıyla silindi";
        public const string ErrorWhileAdding = "Kategori eklenirken bir hata oluştu";
        public const string ErrorWhileUpdating = "Kategori güncellenirken bir hata oluştu";
        public const string ErrorWhileDeleting = "Kategori silinirken bir hata oluştu";
        public const string ErrorWhileFetching = "Kategori getirilirken bir hata oluştu";
    }

    public static class MenuItem
    {
        public const string NotFound = "Menü başarıyla bulunamadı";
        public const string Created = "Menü başarıyla oluşturuldu";
        public const string Updated = "Menü başarıyla güncellendi";
        public const string Deleted = "Menü başarıyla silindi";
        public const string ErrorWhileAdding = "Menü eklenirken bir hata oluştu";
        public const string ErrorWhileUpdating = "Menü güncellenirken bir hata oluştu";
        public const string ErrorWhileDeleting = "Menü silinirken bir hata oluştu";
        public const string ErrorWhileFetching = "Menü getirilirken bir hata oluştu";
    }

    public static class Table
    {
        public const string NotFound = "Masa bulunamadı";
        public const string Created = "Masa başarıyla oluşturuldu";
        public const string Updated = "Masa başarıyla güncellendi";
        public const string Deleted = "Masa başarıyla silindi";
        public const string ErrorWhileAdding = "Masa eklenirken bir hata oluştu";
        public const string ErrorWhileUpdating = "Masa güncellenirken bir hata oluştu";
        public const string ErrorWhileDeleting = "Masa silinirken bir hata oluştu";
        public const string ErrorWhileFetching = "Masa getirilirken bir hata oluştu";
    }

    public static class Order
    {
        public const string NotFound = "Sipariş bulunamadı";
        public const string Created = "Sipariş başarıyla oluşturuldu";
        public const string Updated = "Sipariş başarıyla güncellendi";
        public const string Deleted = "Sipariş başarıyla silindi";
        public const string ErrorWhileAdding = "Sipariş eklenirken bir hata oluştu";
        public const string ErrorWhileUpdating = "Sipariş güncellenirken bir hata oluştu";
        public const string ErrorWhileDeleting = "Sipariş silinirken bir hata oluştu";
        public const string ErrorWhileFetching = "Sipariş getirilirken bir hata oluştu";
    }

    public static class OrderItem
    {
        public const string NotFound = "Sipariş kalemi bulunamadı";
        public const string Created = "Sipariş kalemi başarıyla oluşturuldu";
        public const string Updated = "Sipariş kalemi başarıyla güncellendi";
        public const string Deleted = "Sipariş kalemi başarıyla silindi";
        public const string ErrorWhileAdding = "Sipariş kalemi eklenirken bir hata oluştu";
        public const string ErrorWhileUpdating = "Sipariş kalemi güncellenirken bir hata oluştu";
        public const string ErrorWhileDeleting = "Sipariş kalemi silinirken bir hata oluştu";
        public const string ErrorWhileFetching = "Sipariş kalemi getirilirken bir hata oluştu";
    }
}