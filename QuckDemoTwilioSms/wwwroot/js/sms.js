
function SendSms() {

    var phoneNumber = $("#phoneNumberInput").val();
    var message = $("#messageInput").val();
    var detail = {
        PhoneNumber: phoneNumber,
        Message: message
    }

    Validate(phoneNumber);

    var detail = JSON.stringify(detail);

    $.ajax({
        type: "POST",
        url: '/sms/sendsms',
        dataType: 'JSON',
        data: detail,
        contentType: "application/json",
    });
/*    setTimeout(function () {
        window.location.reload();
    }, 2000);
*/
}

function Validate(phoneNumber) {


    var regex = '^(((\\+44\\s?\\d{4}|\\(?0\\d{4}\\)?)\\s?\\d{3}\\s?\\d{3})|((\\+44\\s?\\d{3}|\\(?0\\d{3}\\)?)\\s?\\d{3}\\s?\\d{4})|((\\+44\\s?\\d{2}|\\(?0\\d{2}\\)?)\\s?\\d{4}\\s?\\d{4}))(\\s?\\#(\\d{4}|\\d{3}))?$';
    const isPhoneNumberValid = new RegExp(regex).test(phoneNumber);
    var buildValidationMessage= "";

    if (isPhoneNumberValid == false) {
        buildValidationMessage = "Phone number should be in a valid UK format" + "";
/*        document.getElementById("ErrorMessage").innerHTML = "Phone number should be in a valid UK format";
*/        document.getElementById("ErrorMessage").style.color = "#FF0000";

        return;
    }

    if (phoneNumber === "") {
        buildValidationMessage = "Phone Number should not be empty!"+"";
/*        document.getElementById("ErrorMessage").innerHTML = "Phone Number should not be empty!";
*/        document.getElementById("ErrorMessage").style.color = "#FF0000";

        return;
    }

    if (message === "") {
        buildValidationMessage = "Message should not be empty!"+"";
  /*      document.getElementById("ErrorMessage").innerHTML = "Message should not be empty!";*/
        document.getElementById("ErrorMessage").style.color = "#FF0000";

        return;
    }
        document.getElementById("ErrorMessage").innerHTML = buildValidationMessage;
    document.getElementById("ErrorMessage").style.color = "#FF0000";

}