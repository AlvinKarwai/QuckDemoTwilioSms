
function SendSms() {

    var phonNumber = $("#phoneNumberInput").val();
    var message = $("#messageInput").val();

    var HealingScripture = {
        PhoneNumber: phonNumber,
        Message: message
    }

    var detail = JSON.stringify(HealingScripture);

    $.ajax({
        type: "POST",
        url: '/sms/sendsms',
        dataType: 'JSON',
        data: detail,
        contentType: "application/json",
    });
    setTimeout(function () {
        window.location.reload();
    }, 2000);

}