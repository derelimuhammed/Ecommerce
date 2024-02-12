using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        // General Messages
        public static string AddedSuccesfully => "Başarıyla eklendi";
        public static string UpdatedSuccessfully => "Başarıyla güncellendi";
        public static string DeletedSuccessfully => "Başarıyla silindi";
        public static string NotFound => "Entity bulunamadı";

        //Auth Manager
        public static string UserNameOrPasswordIsIncorrect => "Kullanıcı adı veya şifre yanlış";
        public static string ConfirmYourAccount => "Lütfen hesabınızı onaylayın";
        public static string EmailIsAlreadyExist => "E-posta zaten mevcut";
        public static string UsernameIsAlreadyExist => "Kullanıcı adı zaten mevcut";
        public static string RegisterSuccessfully => "Başarılı bir şekilde kaydolundu, lütfen hesap onayı için posta kutunuza bakın.";
        public static string UserNotFound => "Kullanıcı bulunamadı";
        public static string TokenOrUserNotFound => "Token veya Kullanıcı Bulunamadı";
        public static string RefreshTokenNotFound => "Yenileme Jetonu Bulunamadı";
        public static string AlreadyAccountConfirmed => "Hesabınız zaten onaylandı";
        public static string SuccessfullyAccountConfirmed => "Hesap başarıyla onaylandı.Şimdi giriş yapabilirsiniz";
        public static string AccountDontConfirmed => "Hesap Onaylanmadı";
        public static string LogoutSuccessfully => "Başarıyla çıkış yapın";

        public static string RefreshTokenExpired => "Jeton Yenilemenin Süresi Doldu";

        //User Service
        public static string CurrentPasswordIsFalse => "Mevcut şifre yanlış";
        public static string PasswordDontMatchWithConfirmation => "Şifre onayıyla eşleşmiyor";
        public static string PasswordChangedSuccessfully => "Parola başarıyla değiştirildi";
        public static string IfEmailTrue => "Kayıtlı e-posta adresinizi doldurduğunuzda, şifrenizi nasıl sıfırlayacağınıza ilişkin talimatlar tarafınıza gönderilecektir.";
        public static string PasswordResetSuccessfully => "Şifre başarıyla sıfırlandı";

        // Order Manager

        public static string YourOrderIsBeingProcessed => "Siparişiniz işleniyor.";
        public static string PaymentFailed => "Ödeme başarısız";

        // Role Manager 

        public static string RoleNameIsAlreadyExist => "Rol adı zaten mevcut";
        public static string RoleAssignedSuccessfully => "Rol başarıyla atandı";
    }
}
