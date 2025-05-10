namespace CupAPI.Application.Common.Constants;

public static class Messages
{
    public static class General
    {
        public const string UnexpectedErrorOccurred = "Beklenmeyen bir hata oluştu. Lütfen daha sonra tekrar deneyin."; // (500 - Internal Server Error)
        public const string DataNotFound = "Kayıt bulunamadı."; // Veri Bulunamadı (404 - NotFound)
        public const string ValidatorNotFound = "Validator bulunamadı."; // Validasyon Hataları (422)
        public const string OperationSuccessful = "İşlem başarılı."; // None (200)
        public const string DataIsEmpty = "Veri mevcut ancak boş."; // Veri boş (200 - Empty List)
    }

    public static class Category
    {
        public const string NotFound = "Kategori bulunamadı";
        public const string Created = "Kategori oluşturuldu";
        public const string Updated = "Kategori güncellendi";
        public const string Deleted = "Kategori silindi";
        public const string ErrorWhileAdding = "Kategori eklenirken bir hata oluştu";
        public const string ErrorWhileUpdating = "Kategori güncellenirken bir hata oluştu";
        public const string ErrorWhileDeleting = "Kategori silinirken bir hata oluştu";
        public const string ErrorWhileFetching = "Kategori getirilirken bir hata oluştu";
    }

    public static class MenuItem
    {
        public const string NotFound = "Menü bulunamadı";
        public const string Created = "Menü oluşturuldu";
        public const string Updated = "Menü güncellendi";
        public const string Deleted = "Menü silindi";
        public const string ErrorWhileAdding = "Menü eklenirken bir hata oluştu";
        public const string ErrorWhileUpdating = "Menü güncellenirken bir hata oluştu";
        public const string ErrorWhileDeleting = "Menü silinirken bir hata oluştu";
        public const string ErrorWhileFetching = "Menü getirilirken bir hata oluştu";
    }

    public static class Table
    {
        public const string NotFound = "Masa bulunamadı";
        public const string Created = "Masa oluşturuldu";
        public const string Updated = "Masa güncellendi";
        public const string Deleted = "Masa silindi";
        public const string ErrorWhileAdding = "Masa eklenirken bir hata oluştu";
        public const string ErrorWhileUpdating = "Masa güncellenirken bir hata oluştu";
        public const string ErrorWhileDeleting = "Masa silinirken bir hata oluştu";
        public const string ErrorWhileFetching = "Masa getirilirken bir hata oluştu";
    }
}
