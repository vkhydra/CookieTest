function exibeAlertaCookie() {
    var myModal = new bootstrap.Modal(document.getElementById("myModal"),
        {
            backdrop: 'static',
            keyboard: false
        });
    myModal.show();
    myModal.hidePrevented;
}
$("#btnAcceptPolicy").on("click", () => {
    $.post("/Home/GravaCookie");
});
$(document).ready(function () {
    var x;
    $.get("/Home/VerificaCookie").fail(() => {
        exibeAlertaCookie();
    });
});