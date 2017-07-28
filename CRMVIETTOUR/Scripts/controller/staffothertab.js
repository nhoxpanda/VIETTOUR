﻿
function OnSuccessAppointment() {
    $("#modal-insert-appointment").modal("hide");
    $("#modal-edit-appointment").modal("hide");
    $('form').trigger("reset");
    CKupdate();

    $("#modal-insert-contacthistory").modal("hide");
    $("#modal-edit-contacthistory").modal("hide");
}

function OnFailureAppointment() {
    alert("Lỗi, vui lòng kiểm tra lại!");
    $("#modal-insert-appointment").modal("hide");
    $("#modal-edit-appointment").modal("hide");
    $('form').trigger("reset");
    CKupdate();

    $("#modal-insert-contacthistory").modal("hide");
    $("#modal-edit-contacthistory").modal("hide");
}

///** xóa lịch hẹn **/
//function deleteAppointment(id) {
//    var dataPost = { id: id };
//    $.ajax({
//        type: "POST",
//        url: '/StaffOtherTab/DeleteAppointment',
//        data: JSON.stringify(dataPost),
//        contentType: "application/json; charset=utf-8",
//        dataType: "html",
//        success: function (data) {
//            alert("Xóa dữ liệu thành công!!!");
//            $("#lichhen").html(data);
//        }
//    });
//}

///** cập nhật lịch hẹn **/
//function updateAppointment(id) {
//    var dataPost = { id: id };
//    $.ajax({
//        type: "POST",
//        url: '/StaffOtherTab/EditAppointment',
//        data: JSON.stringify(dataPost),
//        contentType: "application/json; charset=utf-8",
//        dataType: "html",
//        success: function (data) {
//            $("#info-data-appoinment").html(data);
//            $("#edit-tour-lichhen").select2();
//            $("#edit-program-lichhen").select2();
//            $("#edit-task-lichhen").select2();
//            $("#edit-status-lichhen").select2();
//            $("#edit-service-lichhen").select2();
//            $("#edit-partner-lichhen").select2();
//            $("#edit-type-lichhen").select2();
//            $("#edit-partner-lichhen").select2();
//            $("#edit-ngayhen-lichhen").datepicker();
//            CKEDITOR.replace("edit-note-lichhen");
//            $("#edit-check-notify").click(function () {
//                if (this.checked) {
//                    $("#edit-nhactruoc-lichhen").removeAttr("disabled", "disabled");
//                    $("#edit-nhactruoc-lichhen").select2();
//                }
//                else {
//                    $("#edit-nhactruoc-lichhen").attr("disabled", "disabled");
//                }
//            });

//            $("#edit-check-repeat").click(function () {
//                if (this.checked) {
//                    $("#edit-laplai-lichhen").removeAttr("disabled", "disabled");
//                    $("#edit-laplai-lichhen").select2();
//                }
//                else {
//                    $("#edit-laplai-lichhen").attr("disabled", "disabled");
//                }
//            });

//            $('#edit-service-lichhen').change(function () {
//                $.getJSON('/StaffOtherTab/LoadPartner/' + $('#edit-service-lichhen').val(), function (data) {
//                    var items = '<option value=' + 0 + '>-- Chọn đối tác --</option>';
//                    $.each(data, function (i, ward) {
//                        items += "<option value='" + ward.Value + "'>" + ward.Text + "</option>";
//                    });
//                    $('#edit-partner-lichhen').html(items);
//                });
//            });

//            $("#modal-edit-appointment").modal("show");
//        }
//    });
//}

///** xóa lịch sử liên hệ **/
//function deleteContactHistory(id) {
//    var dataPost = { id: id };
//    $.ajax({
//        type: "POST",
//        url: '/StaffOtherTab/DeleteContactHistory',
//        data: JSON.stringify(dataPost),
//        contentType: "application/json; charset=utf-8",
//        dataType: "html",
//        success: function (data) {
//            alert("Xóa dữ liệu thành công!!!");
//            $("#lichsulienhe").html(data);
//        }
//    });
//}

/** xóa nhiệm vụ **/
function deleteTask(id) {
    if (confirm('Bạn thực sự muốn xóa mục này ?')) {
        var dataPost = {
            id: id,
            idstaff: $("#txtIdStaff").val()
        };
        $.ajax({
            type: "POST",
            url: '/StaffOtherTab/DeleteTask',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                alert("Xóa dữ liệu thành công!!!");
                $("#nhiemvu").html(data);
            }
        });
    }
}

/** cập nhật nhiệm vụ **/
function updateTask(id) {
    var dataPost = {
        id: id,
        idstaff: $("#txtIdStaff").val()
    };
        $.ajax({
            type: "POST",
            url: '/StaffOtherTab/EditTask',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                if (data == 1) {
                    alert('Bạn không được chỉnh sửa nhiệm vụ này!');
                }
                else {
                    $("#info-data-task").html(data);
                    $("#edit-task-type").select2();
                    $("#edit-timetype-task").select2();
                    $("#edit-priority-task").select2();
                    $("#edit-tour-task").select2();
                    $("#edit-status-task").select2();
                    CKEDITOR.replace("edit-note-tourtask");
                    $("#modal-edit-stafftask").modal("show");
                }
            }
        });
}

/** check visa **/
$("#insert-visa-staff").change(function () {
    var dataPost = {
        text: $("#insert-visa-staff").val()
    };
    $.ajax({
        type: "POST",
        url: '/StaffManage/CheckVisa',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            if (data == "1") { // trùng
                alert("Dữ liệu trùng lắp! Vui lòng nhập lại!");
                    $("#insert-visa-staff").val('');
                    $("#insert-visa-staff").focus();
                
            }
        }
    });
});