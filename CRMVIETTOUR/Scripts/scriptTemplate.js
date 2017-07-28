$(document).ready(function () {
    $("[data-toggle='collapse']").click(function (e) {
        var $this = $(this);
        var $icon = $this.find("i");

        if ($icon.hasClass('fa-minus')) {
            $icon.removeClass('fa-minus').addClass('fa-plus');
        } else {
            $icon.removeClass('fa-plus').addClass('fa-minus');
        }
    });
});

$("#btnLogOff").click(function () {
    document.getElementById('logoutForm').submit();
});

function closeChat() {
    $("ul.media-list").css("display", "block");
    $(".page-quick-sidebar-item").css("margin-left", "320px");
}

function colorpicker() {
    var demo1 = $('#txtNote');
    demo1.colorpickerplus();
    demo1.on('changeColor', function (e, color) {
        if (color == null)
            $(this).val('transparent').css('background-color', '#fff');//tranparent
        else
            $(this).val(color).css('background-color', color);
    });
};

function colResize() {
    var innerHTML = $("#tableDictionary-Wrapper").html();
    var onTablesCreated = function () {
        $("#tableDictionary").colResizable({
            liveDrag: true,
            gripInnerHtml: "<div class='grip'></div>",
            draggingClass: "dragging",
            resizeMode: 'overflow',
            postbackSafe: true,
            partialRefresh: true
        });
    }
    var onPostbackOver = function () {
        onTablesCreated();
    };
    onPostbackOver();
};