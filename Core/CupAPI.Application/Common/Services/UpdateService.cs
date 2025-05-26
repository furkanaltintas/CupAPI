using AutoMapper;
using CupAPI.Application.Common.Constants;
using CupAPI.Application.Common.Enums;
using CupAPI.Application.Common.Helpers.Validation.Abstract;

namespace CupAPI.Application.Common.Services;

public class UpdateService(IMapper mapper, IValidationHelper validator)
{
    public async Task<ApiResponse<TResult>> HandleAsync<TDto, TEntity, TResult>(
        TDto dto,
        Func<TDto, int> idSelector,
        Func<int, Task<TEntity>> fetchEntity,
        Action<TEntity> updateEntity,
        Func<TEntity, Task> saveEntity,
        string successMessage)
        where TDto : class
        where TEntity : class
    {
        var validateResponse = await validator.ValidateAsync<TDto, TResult>(dto);
        if (!validateResponse.Success) return validateResponse;

        var entity = await fetchEntity(idSelector(dto));
        if (entity is null) return ApiResponse<TResult>.Fail(Messages.General.DataNotFound, ErrorCodeEnum.NotFound);

        mapper.Map(dto, entity);
        updateEntity(entity);
        await saveEntity(entity);

        return ApiResponse<TResult>.SuccessNoDataResult(successMessage);
    }
}

/*

UPDATE SERVICE

Amaç:
Bir varlığın (entity) güncellenmesini genel bir yapıyla yönetmek:
Doğrulama yapar
Varlığı getirir
Map'ler
Günceller
Başarı durumunu döner


METOT AÇIKLAMASI


PARAMETRELER

TDto: Güncelleme isteği olarak gelen DTO sınıfı
TEntity: Güncellenecek varlık sınıfı
TResult: Metodun döndüreceği sonuç türü
idSelector: DTO içinde Id bilgisini almak için kullanılır
fetchEntity: Güncellenecek varlığı veritabanından almak için kullanılır
updateEntity: Varlığı güncellemek için kullanılır
successMessage: Başarılı durumda gösterilecek mesaj.
 

Akış:
DTO doğrulanır.
Id ile ilgili entity bulunur.
Bulunamazsa hata döner.
mapper.Map(dto, entity) ile DTO'dan entity'e veri aktarılır.
Güncelleme yapılır.
Başarılı sonuç döner.


------------------------------------------------------------------------------


CREATE SERVICE

Amaç:
Yeni bir varlığı (entity) genel şekilde oluşturmak:
Doğrulama yapar
Map'ler
Veritabanına ekler
Başarı mesajı döner


METOT AÇIKLAMASI


PARAMETRELER

TDto: Oluşturma isteği olarak gelen DTO sınıfı
TEntity: Oluşturulacak varlık sınıfı
TResult: Metodun döndüreceği sonuç türü
saveEntity: Yeni varlığı veritabanına eklemek için kullanılır
successMessage: Başarılı durumda gösterilecek mesaj
 

Akış:
DTO doğrulanır.
DTO'dan entity map edilir.
Kaydedilir.
Başarılı sonuç döner.


*/