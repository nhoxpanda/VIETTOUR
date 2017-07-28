//$("#NLHFullName").on('change', function () {
//    alert("testing");
//    var dataPost = {
//        text: $("#NLHFullName").val()
//    };
//    $.ajax({
//        type: "POST",
//        url: '/CustomersManage/CheckFullname',
//        data: JSON.stringify(dataPost),
//        success: function (data) {
//            if (data == "1") { // trùng
//                alert("Dữ liệu trùng lắp! Vui lòng nhập lại!");
//                $("#NLHFullName").val('');
//                $("#NLHFullName").focus();

//            }
//        }
//    });
//});