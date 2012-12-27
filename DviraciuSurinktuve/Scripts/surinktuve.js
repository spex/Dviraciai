$(document).ready(function () {
    $(".detales-grupe .handle").click(function (e) {
        e.stopPropagation();
        var me = $(this),
            parent = me.parent();
        if (parent.hasClass("open")) {
            parent.removeClass("open");
            parent.addClass("closed");
            me.html("+");
        } else {
            parent.removeClass("closed");
            parent.addClass("open");
            me.html("-");
        }
    });
    $(".detale").click(function () {
        var me = $(this),
            myId = me.attr("data-detId");
        $.ajax({
            url: "Surinktuve/RodytiParametrus",
            type: "POST",
            data: { detId: myId },
            success: function (result) {
                $("#detales-parametrai").html(result);
                bindPridetiDetale();
            }
        });
    });
});

function bindPridetiDetale() {
    $(".prideti-detale").click(function (e) {
        var me = $(this),
            parent = me.closest(".detales-aprasymas"),
            detId = parent.attr("data-detId");
        $.ajax({
            url: "Surinktuve/PridetiDetaleKomplektacijai",
            type: "POST",
            data: { detId: detId },
            success: function (result) {
                $("#komplektacijos-langas").html(result);
            }
        });
    });

}
