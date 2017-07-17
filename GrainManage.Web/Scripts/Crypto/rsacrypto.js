
function cmdRsaEncrypt() {
    $("#EncryptFlag").val("RSA");
    setMaxDigits(129);
    var exponent = $("#exponent").val();
    var modulus = $("#modulus").val();
    var key = new RSAKeyPair(exponent, "", modulus);
    $("input[type='password']").each(function () {
        var pwd = $(this).val();
        if (pwd != null || pwd.length < 60) {
            var pwdRtn = encryptedString(key, pwd);
            $(this).val(pwdRtn);
        }
    });
}

function bindFormEvent(formID) {
    $("input[type='text'],input[type='password']").click(function (envent) {
        if ($("#result").has("label")) {
            $("#result").empty();
        }
    });

    $(formID).submit(function (envent) {
        cmdRsaEncrypt();
    });
}