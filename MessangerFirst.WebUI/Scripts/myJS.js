$(document).ready(function () {
    if ($("#AlertMessage").length > 0) {
        $("#AlertMessage").hide();
        var message = $("#AlertMessage").html();
        if (message.length > 0) {
            toastr.success(message);
        }
    }

})