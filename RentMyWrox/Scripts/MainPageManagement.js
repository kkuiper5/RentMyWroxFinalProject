function getStoreHours() {
    $.getJSON("/StoreOpen")
        .done(function (data) {
            var message = data.Message;
            $("#storeHoursMessage").html(message);
            $("#storeHoursMessage").removeClass();
            if (data.IsStoreOpenNow == false) {
                $("#storeHoursMessage").addClass("storeClosed");
            } else {
                $("#storeHoursMessage").addClass("storeOpen");
            }
            setTimeout(function () {
                getStoreHours();
            }, 20000);
        });
};

function fadeOutShoppingCartSummary() {
    $("#shoppingcartsummary").fadeOut(250);
}

function fadeInShoppingCartSummary() {
    $("#shoppingcartsummary").fadeIn(1000);
}

$(document).ready(function () {
    getStoreHours();
});