
function SendSms() {

    var phoneNumber = $("#phoneNumberInput").val();
    var message = $("#messageInput").val();
    var sendSms = true;
    var detail = {
        PhoneNumber: phoneNumber,
        Message: message
    }

    let errorMessage = [];

    var regex = '^(((\\+44\\s?\\d{4}|\\(?0\\d{4}\\)?)\\s?\\d{3}\\s?\\d{3})|((\\+44\\s?\\d{3}|\\(?0\\d{3}\\)?)\\s?\\d{3}\\s?\\d{4})|((\\+44\\s?\\d{2}|\\(?0\\d{2}\\)?)\\s?\\d{4}\\s?\\d{4}))(\\s?\\#(\\d{4}|\\d{3}))?$';
    const isPhoneNumberValid = new RegExp(regex).test(phoneNumber);


    if (phoneNumber === "" ) {

        errorMessage.push("Phone Number should not be empty!");
        sendSms = false;
    }

    if (isPhoneNumberValid === false && phoneNumber != "") {
        errorMessage.push("Phone number should be in a valid UK format");
        sendSms = false;
    }

    if (message === "") {
        errorMessage.push("Message should not be empty!");
  
        sendSms = false;
    }

    if (sendSms == false) {
        document.getElementById("ErrorMessage").innerHTML = errorMessage;
        document.getElementById("ErrorMessage").style.color = "#FF0000";
    }

    var detail = JSON.stringify(detail);

    if (sendSms == true) {
        $.ajax({
            type: "POST",
            url: '/sms/sendsms',
            dataType: 'JSON',
            data: detail,
            contentType: "application/json",
        });
    }

}
