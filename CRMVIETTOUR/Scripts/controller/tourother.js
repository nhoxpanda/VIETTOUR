﻿CKEDITOR.replace("insert-request-tour");
CKEDITOR.replace("insert-noteflight-tour");
CKEDITOR.replace("insert-note-lichhen");
CKEDITOR.replace("insert-note-lienhe");
CKEDITOR.replace("insert-document-note");
CKEDITOR.replace("insert-program-note");
CKEDITOR.replace("insert-note-tourtask");
CKEDITOR.replace("insert-note-contracttour");
CKEDITOR.replace("insert-note-reviewtour");
CKEDITOR.replace("insert-note-liabilitycustomer");
CKEDITOR.replace("insert-note-quotation");
CKEDITOR.replace("insert-note-congnodt1");

$("#insert-service-tour").select2();
$("#insert-partner-tour").select2();
$("#insert-servicepartner-tour").select2();
$("#insert-method-congno1").select2();
$("#insert-partner-congno1").select2();
//---------
$("#update-country").select2();
$("#update-status-visa").select2();
$("#update-type-visa").select2();
//---------
$("#insert-ngayhen-lichhen").val(moment(new Date()).format("YYYY-MM-DD") + "T08:30");

$('#insert-service-tour').change(function () {
    $.getJSON('/TourOtherTab/LoadPartner/' + $('#insert-service-tour').val(), function (data) {
        var items = '<option>-- Chọn đối tác --</option>';
        $.each(data, function (i, ward) {
            items += "<option value='" + ward.Value + "'>" + ward.Text + "</option>";
        });
        $('#insert-partner-tour').html(items);
    });
});

$('#edit-partner-dichvu').change(function () {
    $.getJSON('/TourOtherTab/LoadPartner/' + $('#edit-partner-dichvu').val(), function (data) {
        var items = "";
        $.each(data, function (i, ward) {
            items += "<option value='" + ward.Value + "'>" + ward.Text + "</option>";
        });
        $('#edit-partner-congno').html(items);
    });
});

$('#insert-partner-tour').change(function () {
    $.getJSON('/TourOtherTab/LoadServicePartner/' + $('#insert-partner-tour').val(), function (data) {
        var items = '<option>-- Chọn dịch vụ của đối tác --</option>';
        $.each(data, function (i, ward) {
            items += "<option value='" + ward.Value + "'>" + ward.Text + "</option>";
        });
        $('#insert-servicepartner-tour').html(items);
    });
});

/** thêm mới tài liệu **/
function btnCreateFile() {
    if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
        alert("Vui lòng chọn 1 tour!");
    }
    else {
        var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };

        $.ajax({
            type: "POST",
            url: '/TourManage/GetIdTour',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                $("#insert-document-type").select2();
                $("#insert-tag-document").select2();
                $("#modal-insert-document").modal("show");
            }
        });
    }
}

/** thêm mới chương trình **/
function btnCreateProgram() {
    if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
        alert("Vui lòng chọn 1 tour!");
    }
    else {
        var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };

        $.ajax({
            type: "POST",
            url: '/TourManage/GetIdTour',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                $("#insert-tag-program").select2();
                $("#insert-status-program").select2();
                $("#modal-insert-program").modal("show");
            }
        });
    }
}

/** thêm mới lịch hẹn **/
function btnAddLichHen() {
    if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
        alert("Vui lòng chọn 1 tour!");
    }
    else {
        var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };

        $.ajax({
            type: "POST",
            url: '/TourManage/GetIdTour',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                $("#insert-tour-lichhen").select2();
                $("#insert-program-lichhen").select2();
                $("#insert-staff-customer").select2();
                $("#insert-task-lichhen").select2();
                $("#insert-status-lichhen").select2();
                $("#insert-service-lichhen").select2();
                $("#insert-partner-lichhen").select2();
                $("#insert-type-lichhen").select2();
                $("#insert-partner-lichhen").select2();
                //$("#insert-ngayhen-lichhen").datepicker();
                ///
                $("#insert-check-notify").click(function () {
                    if (this.checked) {
                        $("#insert-nhactruoc-lichhen").removeAttr("disabled", "disabled");
                        $("#insert-nhactruoc-lichhen").select2();
                    }
                    else {
                        $("#insert-nhactruoc-lichhen").attr("disabled", "disabled");
                    }
                });

                $("#insert-check-repeat").click(function () {
                    if (this.checked) {
                        $("#insert-laplai-lichhen").removeAttr("disabled", "disabled");
                        $("#insert-laplai-lichhen").select2();
                    }
                    else {
                        $("#insert-laplai-lichhen").attr("disabled", "disabled");
                    }
                });

                $('#insert-service-lichhen').change(function () {
                    $.getJSON('/TourOtherTab/LoadPartner/' + $('#insert-service-lichhen').val(), function (data) {
                        var items = '<option>-- Chọn đối tác --</option>';
                        $.each(data, function (i, ward) {
                            items += "<option value='" + ward.Value + "'>" + ward.Text + "</option>";
                        });
                        $('#insert-partner-lichhen').html(items);
                    });
                });
                $("#modal-insert-appointment").modal("show");
            }
        });
    }
}

/** thêm mới lịch sử liên hệ **/
function btnAddLichSuLienHe() {
    if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
        alert("Vui lòng chọn 1 tour!");
    }
    else {
        var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };

        $.ajax({
            type: "POST",
            url: '/TourManage/GetIdTour',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                $("#insert-type-lienhe").select2();
                //$("#insert-ngay-lienhe").datepicker();
                $("#modal-insert-contacthistory").modal("show");
            }
        });
    }
}

$('#FileNameProgram').change(function () {
    var data = new FormData();
    data.append('FileName', $('#FileNameProgram')[0].files[0]);

    var ajaxRequest = $.ajax({
        type: "POST",
        url: 'TourOtherTab/UploadProgram',
        contentType: false,
        processData: false,
        data: data
    });

    ajaxRequest.done(function (xhr, textStatus) {
        // Onsuccess
    });
});

$('#FileName').change(function () {
    var data = new FormData();
    data.append('FileName', $('#FileName')[0].files[0]);

    var ajaxRequest = $.ajax({
        type: "POST",
        url: 'TourOtherTab/UploadFile',
        contentType: false,
        processData: false,
        data: data
    });

    ajaxRequest.done(function (xhr, textStatus) {
        // Onsuccess
    });
});

/** cập nhật lịch hẹn **/
function updateAppointment(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/TourOtherTab/EditAppointment',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $("#info-data-appoinment").html(data);
            $("#edit-tour-lichhen").select2();
            $("#edit-program-lichhen").select2();
            $("#edit-task-lichhen").select2();
            $("#edit-status-lichhen").select2();
            $("#edit-service-lichhen").select2();
            $("#edit-partner-lichhen").select2();
            $("#edit-type-lichhen").select2();
            $("#edit-partner-lichhen").select2();
            $("#edit-staff-customer").select2();
            $("#edit-check-notify").click(function () {
                if (this.checked) {
                    $("#edit-nhactruoc-lichhen").removeAttr("disabled", "disabled");
                    $("#edit-nhactruoc-lichhen").select2();
                }
                else {
                    $("#edit-nhactruoc-lichhen").attr("disabled", "disabled");
                }
            });

            $("#edit-check-repeat").click(function () {
                if (this.checked) {
                    $("#edit-laplai-lichhen").removeAttr("disabled", "disabled");
                    $("#edit-laplai-lichhen").select2();
                }
                else {
                    $("#edit-laplai-lichhen").attr("disabled", "disabled");
                }
            });

            $('#edit-service-lichhen').change(function () {
                $.getJSON('/TourOtherTab/LoadPartner/' + $('#edit-service-lichhen').val(), function (data) {
                    var items = '<option value=' + 0 + '>-- Chọn đối tác --</option>';
                    $.each(data, function (i, ward) {
                        items += "<option value='" + ward.Value + "'>" + ward.Text + "</option>";
                    });
                    $('#edit-partner-lichhen').html(items);
                });
            });

            CKEDITOR.replace("edit-note-lichhen");
            $("#modal-edit-appointment").modal("show");
        }
    });
}

/** cập nhật lịch sử liên hệ **/
function updateContactHistory(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/TourOtherTab/EditContactHistory',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $("#info-data-contacthistory").html(data);
            //$("#edit-ngay-lienhe").datepicker();
            $("#edit-type-lienhe").select2();
            CKEDITOR.replace("edit-note-lienhe");
            $("#modal-edit-contacthistory").modal("show");
        }
    });
}

/** cập nhật nhiệm vụ **/
function updateTask(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/TourOtherTab/EditTask',
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
                $("#edit-department-tasktour").select2();
                $("#edit-staff-tasktour").select2();
                $("#edit-priority-task").select2();
                CKEDITOR.replace("edit-note-tourtask");
                $("#modal-edit-tourtask").modal("show");

                $('#edit-department-tasktour').change(function () {
                    $.getJSON('/TourManage/LoadPermission/' + $('#edit-department-tasktour').val(), function (data) {
                        var items = '<option>-- Chọn nhân viên thực hiện --</option>';
                        $.each(data, function (i, ward) {
                            items += "<option value='" + ward.Value + "'>" + ward.Text + "</option>";
                        });
                        $('#edit-staff-tasktour').html(items);
                    });
                });
            }
        }
    });
}

/** xóa tài liệu **/
function deleteDocument(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/TourOtherTab/DeleteDocument',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            alert("Xóa dữ liệu thành công!!!");
            $("#tailieumau").html(data);
        }
    });
}

/** cập nhật tài liệu **/
function updateDocument(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/TourOtherTab/EditInfoDocument',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $("#info-data-doc").html(data);
            $("#edit-tag-document").select2();
            $("#edit-document-type").select2();
            CKEDITOR.replace("edit-document-note");
            $("#modal-edit-document").modal("show");
            /**** update in tab file của khách hàng ****/
            $("#btnUpdateFile").click(function () {
                var $this = $(this);
                var $form = $("#frmUpdateFile");
                var $parent = $form.parent();
                var options = {
                    url: $form.attr("action"),
                    type: $form.attr("method"),
                    data: $form.serialize()
                };

                $.ajax(options).done(function (data) {
                    $("#modal-edit-document").modal("hide");
                    alert("Lưu dữ liệu thành công!");
                    $("#hosolienquan").html(data);
                });
                return false;
            });

            /** upload file **/
            $("#edit-file").change(function () {
                var data = new FormData();
                data.append('FileName', $('#edit-file')[0].files[0]);
                var ajaxRequest = $.ajax({
                    type: "POST",
                    url: 'TourOtherTab/UploadFile',
                    contentType: false,
                    processData: false,
                    data: data
                });

                ajaxRequest.done(function (xhr, textStatus) {
                    // Onsuccess
                });
            });
        }
    });
}

function OnSuccessCNKH() {
    $("#modal-insert-congnokh").modal("hide");
    $("#modal-edit-congnokh").modal("hide");
    $('form').trigger("reset");

    $.ajax({
        type: "POST",
        url: '/TourOtherTab/CNKH',
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            var obj = jQuery.parseJSON(data);
            $("#cnkh" + obj.Id).html(numeral(obj.CongNo).format('0,0'));
        }
    });

}
function OnSuccessCNDT() {
    $('form').trigger("reset");
    $("#modal-insert-congnodt").modal("hide");
    $("#modal-edit-congnodt").modal("hide");

    $.ajax({
        type: "POST",
        url: '/TourOtherTab/CNDT',
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            var obj = jQuery.parseJSON(data);
            $("#cndt" + obj.Id).html(numeral(obj.CongNo).format('0,0'));
        }
    });

}
function OnSuccessTourTab() {
    $("#modal-insert-appointment").modal("hide");
    $("#modal-edit-appointment").modal("hide");
    $('form').trigger("reset");
    CKupdate();

    $("#modal-insert-contacthistory").modal("hide");
    $("#modal-edit-contacthistory").modal("hide");

    $("#modal-insert-document").modal("hide");
    $("#modal-edit-document").modal("hide");

    $("#modal-insert-program").modal("hide");
    $("#modal-edit-program").modal("hide");

    $("#modal-insert-contract").modal("hide");
    $("#modal-edit-contract").modal("hide");

    $("#modal-insert-mark").modal("hide");
    $("#modal-edit-mark").modal("hide");

    $("#modal-edit-quotation").modal("hide");
    $("#modal-insert-quotation").modal("hide");

    $("#modal-insert-guide").modal("hide");
    $("#modal-edit-guide").modal("hide");

}
function OnFailureTourTab() {
    alert("Lỗi, vui lòng kiểm tra lại!");
    $('form').trigger("reset");
    CKupdate();

    $("#modal-insert-appointment").modal("hide");
    $("#modal-edit-appointment").modal("hide");

    $("#modal-insert-contacthistory").modal("hide");
    $("#modal-edit-contacthistory").modal("hide");

    $("#modal-insert-document").modal("hide");
    $("#modal-edit-document").modal("hide");

    $("#modal-insert-program").modal("hide");
    $("#modal-edit-program").modal("hide");

    $("#modal-insert-contract").modal("hide");
    $("#modal-edit-contract").modal("hide");

    $("#modal-insert-mark").modal("hide");
    $("#modal-edit-mark").modal("hide");

    $("#modal-insert-congnokh").modal("hide");
    $("#modal-edit-congnokh").modal("hide");

    $("#modal-insert-congnodt").modal("hide");
    $("#modal-edit-congnodt").modal("hide");

    $("#modal-edit-quotation").modal("hide");
    $("#modal-insert-quotation").modal("hide");

    $("#modal-insert-guide").modal("hide");
    $("#modal-edit-guide").modal("hide");
}

/** xóa lịch hẹn **/
function deleteAppointment(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/TourOtherTab/DeleteAppointment',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            alert("Xóa dữ liệu thành công!!!");
            $("#lichhen").html(data);
        }
    });
}

/** xóa lịch sử liên hệ **/
function deleteContactHistory(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/TourOtherTab/DeleteContactHistory',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            alert("Xóa dữ liệu thành công!!!");
            $("#lichsulienhe").html(data);
        }
    });
}

/** xóa nhiệm vụ **/
function deleteTask(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/TourOtherTab/DeleteTask',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            alert("Xóa dữ liệu thành công!!!");
            $("#nhiemvu").html(data);
        }
    });
}

/** xóa chương trình **/
function deleteProgram(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/TourOtherTab/DeleteProgram',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            alert("Xóa dữ liệu thành công!!!");
            $("#chuongtrinh").html(data);
        }
    });
}

/** cập nhật chương trình **/
function updateProgram(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/TourOtherTab/EditInfoProgram',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $("#info-data-program").html(data);
            $("#edit-tag-program").select2();
            $("#edit-program-type").select2();
            $("#edit-status-program").select2();
            CKEDITOR.replace("edit-program-note");
            $("#modal-edit-program").modal("show");
            /**** update in tab file của khách hàng ****/
            $("#btnUpdateProgram").click(function () {
                var $this = $(this);
                var $form = $("#frmUpdateProgram");
                var $parent = $form.parent();
                var options = {
                    url: $form.attr("action"),
                    type: $form.attr("method"),
                    data: $form.serialize()
                };

                $.ajax(options).done(function (data) {
                    $("#modal-edit-program").modal("hide");
                    alert("Lưu dữ liệu thành công!");
                    $("#chuongtrinh").html(data);
                });
                return false;
            });

            /** upload file **/
            $("#edit-program").change(function () {
                var data = new FormData();
                data.append('FileName', $('#edit-program')[0].files[0]);
                var ajaxRequest = $.ajax({
                    type: "POST",
                    url: 'TourOtherTab/UploadProgram',
                    contentType: false,
                    processData: false,
                    data: data
                });

                ajaxRequest.done(function (xhr, textStatus) {
                    // Onsuccess
                });
            });
        }
    });
}

/** thêm mới hợp đồng **/
function btnCreateContract() {
    if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
        alert("Vui lòng chọn 1 tour!");
    }
    else {
        var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };

        $.ajax({
            type: "POST",
            url: '/TourManage/GetIdTour',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                $("#insert-status-contracttour").select2();
                $("#insert-permission-contracttour").select2();
                $("#insert-currency-contracttour").select2();
                $("#insert-tag-contract").select2();
                $("#insert-currency-dukien").select2();
                $("#modal-insert-contract").modal("show");

                /**** upload file contract ****/
                $('#insert-file-contract').change(function () {
                    var data = new FormData();
                    data.append('FileNameContract', $('#insert-file-contract')[0].files[0]);

                    var ajaxRequest = $.ajax({
                        type: "POST",
                        url: 'TourOtherTab/UploadContract',
                        contentType: false,
                        processData: false,
                        data: data
                    });

                    ajaxRequest.done(function (xhr, textStatus) {
                        // Onsuccess
                    });
                });

                checkCodeContract();
            }
        });
    }
}

/** cập nhật hợp đồng **/
function updateContract(id, docId) {
    var dataPost = {
        id: id,
        docId: docId
    };
    $.ajax({
        type: "POST",
        url: '/TourOtherTab/EditContract',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            if (data == 1) {
                alert('Bạn không được chỉnh sửa hợp đồng này!');
            }
            else {
                $("#info-data-contract").html(data);
                $("#edit-status-contracttour").select2();
                $("#edit-currency-contracttour").select2();
                $("#edit-currency-dukien").select2();
                $("#edit-tag-contract").select2();
                $("#edit-permission-contracttour").select2();
                CKEDITOR.replace("edit-note-contracttour");
                $("#modal-edit-contract").modal("show");

                $('#edit-file-contract').change(function () {
                    var data = new FormData();
                    data.append('FileNameContract', $('#edit-file-contract')[0].files[0]);

                    var ajaxRequest = $.ajax({
                        type: "POST",
                        url: 'TourOtherTab/UploadContract',
                        contentType: false,
                        processData: false,
                        data: data
                    });

                    ajaxRequest.done(function (xhr, textStatus) {
                        // Onsuccess
                    });
                });

                checkCodeContract();
            }
        }
    });
}

/** xóa hợp đồng **/
function deleteContract(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/TourOtherTab/DeleteContract',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            alert("Xóa dữ liệu thành công!!!");
            $("#hopdong").html(data);
        }
    });
}

/** thêm mới đánh giá **/
function btnCreateReview() {
    if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
        alert("Vui lòng chọn 1 tour!");
    }
    else {
        var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };

        $.ajax({
            type: "POST",
            url: '/TourManage/GetIdTour',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                $("#insert-tour").select2();
                $("#insert-customer").select2();
                $("#insert-service1").select2();
                $("#modal-insert-mark").modal("show");

                $('#btnAddR').click(function () {
                    var num = $('.clonedInput').length, // how many "duplicatable" input fields we currently have
                        newNum = new Number(num + 1),      // the numeric ID of the new input field being added
                        newElem = $('#entry' + num).clone().attr('id', 'entry' + newNum).fadeIn('slow'); // create the new element via clone(), and manipulate it's ID using newNum value
                    // manipulate the name/id values of the input inside the new element

                    newElem.find('.service').attr('id', 'insert-service' + newNum).attr('name', 'DictionaryId' + newNum);
                    newElem.find('.mark').attr('name', 'Mark' + newNum).val('');

                    // insert the new element after the last "duplicatable" input field
                    $('#entry' + num).after(newElem);
                    $("#countService").val(newNum);
                    $("#insert-service" + newNum).select2();

                    for (var i = 1; i < newNum; i++) {
                        $("#entry" + newNum + " #select2-insert-service" + i + "-container").parent().parent().parent().remove();
                    }

                    // enable the "remove" button
                    $('#btnDel').attr('disabled', false);

                });

                $('#btnDel').click(function () {
                    // confirmation
                    var num = $('.clonedInput').length;
                    // how many "duplicatable" input fields we currently have
                    $('#entry' + num).slideUp('slow', function () {
                        $(this).remove();
                        // if only one element remains, disable the "remove" button
                        if (num - 1 === 1)
                            $('#btnDel').attr('disabled', true);
                        // enable the "add" button
                        $('#btnAddR').attr('disabled', false).prop('value', "add section");
                    });
                    return false;

                    $('#btnAddR').attr('disabled', false);
                });
                $('#btnDel').attr('disabled', true);
            }
        });
    }
}

/** thêm mới công nợ khách hàng **/
function btnCreateLiabilityCustomer() {
    if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
        alert("Vui lòng chọn 1 tour!");
    }
    else {
        var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };

        $.ajax({
            type: "POST",
            url: '/TourManage/GetIdTour',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                $("#modal-insert-congnokh").modal("show");
                $("#insert-currency-congnokh").select2();
                $("#insert-customer-congnokh").select2();
                $(".Icndt").change(function () {
                    var dot1 = parseInt($("#IcnkhDot1").val()) || 0;
                    var dot2 = parseInt($("#IcnkhDot2").val()) || 0;
                    $("#IcnkhTong").val(dot1 + dot2);
                })
            }
        });
    }
}

/** cập nhật công nợ khách hàng **/
function updateLiabilityCustomer(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/TourOtherTab/EditLiabilityCustomer',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $("#info-data-liabilitycustomer").html(data);
            $("#edit-currency-congnokh").select2();
            $("#edit-customer-congnokh").select2();
            CKEDITOR.replace("edit-note-liabilitycustomer");
            $("#modal-edit-congnokh").modal("show");
            $("#addService").click(function () {
                var count = parseInt($("#CountService").val()) + 1;
                $("#tableService").append('<tr><td><input type="text" class="form-control" id="txtNameS' + count + '" name="txtNameS' + count + '" style="width: 300px" /></td>'
                                        + '<td><input type="number" class="form-control" id="txtQuantityS' + count + '" onchange="calTotalPrice(' + count + ')" name="txtQuantityS' + count + '" /></td>'
                                        + '<td><input type="text" class="form-control" id="txtUnitPriceS' + count + '" onchange="calTotalPrice(' + count + ')" name="txtUnitPriceS' + count + '" /></td>'
                                        + '<td><input type="text" class="form-control" id="txtTotalPriceS' + count + '" name="txtTotalPriceS' + count + '" readonly="readonly" /></td>'
                                        + '<td></td></tr>');
                $("#CountService").val(count);
                $("#txtUnitPriceS" + count).change(function () {
                    calTotalLiquidation();
                });
                $("#txtQuantityS" + count).change(function () {
                    calTotalLiquidation();
                });
            });
            $("#EcnkhTong").change(function () {
                calTotalLiquidation();
            });
            $("#Edit-TotalReturn").change(function () {
                calTotalLiquidation();
            });
        }
    });
}

// tính thành tiền
function calTotalPrice(i) {
    var dataPost = {
        sl: $("#txtQuantityS" + i).val(),
        dg: $("#txtUnitPriceS" + i).val()
    };
    $.ajax({
        type: "POST",
        url: '/Home/CalTotalPrice',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("#txtTotalPriceS" + i).val(data);
        }
    });
}

/** xóa công nợ khách hàng **/
function deleteLiabilityCustomer(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/TourOtherTab/DeleteLiabilityCustomer',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $.ajax({
                type: "POST",
                url: '/TourOtherTab/CNKH',
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                success: function (data) {
                    var obj = jQuery.parseJSON(data);
                    $("#cnkh" + obj.Id).html(numeral(obj.CongNo).format('0,0'));
                }
            });
            alert("Xóa dữ liệu thành công!!!");
            $("#congnokh").html(data);
        }
    });
}

/** xóa dịch vụ khách hàng **/
function deleteServiceCustomer(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/TourOtherTab/DeleteService',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $("#rowS" + id).hide()
        }
    });
}

/** thêm mới công nợ đối tác **/
function btnCreateLiabilityPartner() {
    if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
        alert("Vui lòng chọn 1 tour!");
    }
    else {
        var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };

        $.ajax({
            type: "POST",
            url: '/TourManage/GetIdTour',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                $("#insert-partner-dichvu1").select2();
                $("#insert-partner-congno1").select2();
                $("#insert-method-congno1").select2();
                $("#insert-currencyfirst-congno1").select2();
                $("#modal-insert-congnodt").modal("show");
                /*** duplicate thêm công nợ đối tác ***/
                //$(function () {
                //    $('#btnAddCongNo').click(function () {
                //        var num = $('.clonedInputCongNo').length, // how many "duplicatable" input fields we currently have
                //            newNum = new Number(num + 1),      // the numeric ID of the new input field being added
                //            newElem = $('#entryCongNo' + num).clone().attr('id', 'entryCongNo' + newNum).fadeIn('slow'); // create the new element via clone(), and manipulate it's ID using newNum value
                //        // manipulate the name/id values of the input inside the new element
                //        newElem.find('.congnocurrencyfirst').attr('id', 'insert-currencyfirst-congno' + newNum).attr('name', 'FirstCurrencyType' + newNum);
                //        newElem.find('.congnopartner').attr('id', 'insert-partner-congno' + newNum).attr('name', 'PartnerId' + newNum);
                //        newElem.find('.congnofirst').attr('name', 'FirstPayment' + newNum).val('');
                //        newElem.find('.congnomethod').attr('id', 'insert-method-congno' + newNum).attr('name', 'PaymentMethod' + newNum);
                //        newElem.find('.congnosecond').attr('name', 'SecondPayment' + newNum).val('');
                //        newElem.find('.congnoprice').attr('name', 'ServicePrice' + newNum).val('');
                //        newElem.find('.congnoremaining').attr('name', 'TotalRemaining' + newNum).val('');
                //        newElem.find('.congnonote').attr('id', 'insert-note-congnodt' + newNum).attr('name', 'Note' + newNum).val('');
                //        newElem.find('.collapsedt').attr('data-target', '#demo-congnodt' + newNum);
                //        newElem.find('.optioncongno').attr('id', 'demo-congnodt' + newNum);
                //        newElem.find('.titleoption').text('OPTION ' + newNum);

                //        // insert the new element after the last "duplicatable" input field
                //        $('#entryCongNo' + num).after(newElem);
                //        $("#insert-partner-congno" + newNum).select2();
                //        $("#insert-method-congno" + newNum).select2();
                //        $("#insert-currencyfirst-congno" + newNum).select2();
                //        CKEDITOR.replace("insert-note-congnodt" + newNum);
                //        $("#countOptionCongNo").val(newNum);

                //        for (var i = 1; i < newNum; i++) {
                //            $("#entryCongNo" + newNum + " #select2-insert-currencyfirst-congno" + i + "-container").parent().parent().parent().remove();
                //            $("#entryCongNo" + newNum + " #select2-insert-partner-congno" + i + "-container").parent().parent().parent().remove();
                //            $("#entryCongNo" + newNum + " #select2-insert-method-congno" + i + "-container").parent().parent().parent().remove();
                //            $("#entryCongNo" + newNum).find("#cke_insert-note-congnodt" + i).remove();
                //        }

                //        // enable the "remove" button
                //        $('#btnDelCongNo').attr('disabled', false);

                //    });

                //    $('#btnDelCongNo').click(function () {
                //        // confirmation
                //        var num = $('.clonedInputCongNo').length;
                //        // how many "duplicatable" input fields we currently have
                //        $('#entryCongNo' + num).slideUp('slow', function () {
                //            $(this).remove();
                //            // if only one element remains, disable the "remove" button
                //            if (num - 1 === 1)
                //                $('#btnDelCongNo').attr('disabled', true);
                //            // enable the "add" button
                //            $('#btnAddCongNo').attr('disabled', false).prop('value', "add section");
                //        });
                //        return false;

                //        $('#btnAddCongNo').attr('disabled', false);
                //    });
                //    $('#btnDelCongNo').attr('disabled', true);
                //});
            }
        });
    }
}

/** cập nhật công nợ đối tác **/
function updateLiabilityPartner(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/TourOtherTab/EditLiabilityPartner',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $("#info-data-liabilitypartner").html(data);
            $("#edit-partner-congno").select2();
            $("#edit-partner-dichvu").select2();
            $("#edit-method-congno").select2();
            $("#edit-currencyfirst-congno").select2();
            CKEDITOR.replace("edit-note-congnodt");
            $("#modal-edit-congnodt").modal("show");

            $(".Ecndt").change(function () {
                var tong = $("#ServicePrice").val();
                var dot1 = $("#FirstPayment").val();
                var dot2 = $("#SecondPayment").val();
                $("#TotalRemaining").val(tong - dot1 - dot2);

            })
        }
    });
}

/** xóa công nợ đối tác **/
function deleteLiabilityPartner(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/TourOtherTab/DeleteLiabilityPartner',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $.ajax({
                type: "POST",
                url: '/TourOtherTab/CNDT',
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                success: function (data) {
                    var obj = jQuery.parseJSON(data);
                    $("#cndt" + obj.Id).html(numeral(obj.CongNo).format('0,0'));
                }
            });
            alert("Xóa dữ liệu thành công!!!");
            $("#congnodoitac").html(data);
        }
    });
}

/* thêm mới báo giá */
function btnCreateQuotation() {
    if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
        alert("Vui lòng chọn 1 tour!");
    }
    else {
        var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };

        $.ajax({
            type: "POST",
            url: '/TourManage/GetIdTour',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                $("#insert-code-country").select2();
                $("#insert-tags").select2();
                $("#insert-staff-quotation").select2();
                $("#insert-currency-quotation").select2();
                $("#modal-insert-quotation").modal("show");

                /* upload file báo giá */
                $('#insert-file-quotation').change(function () {
                    var data = new FormData();
                    var totalFiles = document.getElementById("insert-file-quotation").files.length;
                    for (var i = 0; i < totalFiles; i++) {
                        var file = document.getElementById("insert-file-quotation").files[i];
                        data.append('FileNameQuotation', file);
                    }

                    var ajaxRequest = $.ajax({
                        type: "POST",
                        url: 'TourOtherTab/UploadMultipleFileQuotation',
                        contentType: false,
                        processData: false,
                        data: data
                    });

                    ajaxRequest.done(function (xhr, textStatus) {
                        // Onsuccess
                    });
                });
            }
        });
    }
}

/* cập nhật báo giá */
function updateQuotation(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/TourOtherTab/EditQuotation',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $("#info-data-quotation").html(data);
            $("#edit-code-country").select2();
            $("#edit-tags").select2();
            $("#edit-staff-quotation").select2();
            $("#edit-currency-quotation").select2();
            $("#modal-edit-quotation").modal("show");
            CKEDITOR.replace("edit-note-quotation");
            $("#modal-edit-quotation").modal("show");

            /* upload file báo giá */
            $('#edit-file-quotation').change(function () {
                var data = new FormData();
                data.append('FileNameQuotation', $('#edit-file-quotation')[0].files[0]);

                var ajaxRequest = $.ajax({
                    type: "POST",
                    url: 'TourOtherTab/UploadFileQuotation',
                    contentType: false,
                    processData: false,
                    data: data
                });

                ajaxRequest.done(function (xhr, textStatus) {
                    // Onsuccess
                });
            });
        }
    });
}

/* xóa báo giá */
function deleteQuotation(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/TourOtherTab/DeleteQuotation',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            alert("Xóa dữ liệu thành công!!!");
            $("#viettourbaogia").html(data);
        }
    });
}

/** thêm mới hướng dẫn viên **/
function btnAddGuide() {
    if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
        alert("Vui lòng chọn 1 tour!");
    }
    else {
        var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };

        $.ajax({
            type: "POST",
            url: '/TourManage/GetIdTour',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                $("#insert-guide").select2();
                $("#modal-insert-guide").modal("show");

                $("#insert-check").click(function () {
                    if (this.checked) {
                        $("#insert-guide").removeAttr("disabled", "disabled");
                    }
                    else {
                        $("#insert-guide").attr("disabled", "disabled");
                    }
                });

                $("#insert-guide").change(function () {
                    $.getJSON('/CustomerOtherTab/LoadStaffInfo/' + $('#insert-guide').val(), function (data) {
                        console.log(data.Birthday);
                        $("#SingleStaff_FullName").val(data.FullName);
                        $("#SingleStaff_Birthday").val(data.Birthday);
                        $("#SingleStaff_CodeGuide").val(data.CodeGuide);
                    });
                });
            }
        });
    }
}

/** cập nhật hướng dẫn viên **/
function updateGuide(id) {
    var dataPost = { id: id };

    $.ajax({
        type: "POST",
        url: '/TourOtherTab/EditInfoGuide',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $("#info-data-guide").html(data);
            $("#edit-guide").select2();
            $("#modal-edit-guide").modal("show");

            $("#edit-check").click(function () {
                if (this.checked) {
                    $("#edit-guide").removeAttr("disabled", "disabled");
                }
                else {
                    $("#edit-guide").attr("disabled", "disabled");
                }
            });

            $("#edit-guide").change(function () {
                $.getJSON('/CustomerOtherTab/LoadStaffInfo/' + $('#edit-guide').val(), function (data) {
                    $("#fullname").val(data.FullName);
                    $("#birthday").val(data.Birthday);
                    $("#codeguide").val(data.CodeGuide);
                });
            });

            $('#edit-file-guide').change(function () {
                var data = new FormData();
                var totalFiles = document.getElementById("edit-file-guide").files.length;
                for (var i = 0; i < totalFiles; i++) {
                    var file = document.getElementById("edit-file-guide").files[i];
                    data.append('File', file);
                }

                var ajaxRequest = $.ajax({
                    type: "POST",
                    url: 'TourOtherTab/UploadMultipleFile',
                    contentType: false,
                    processData: false,
                    data: data
                });

                ajaxRequest.done(function (xhr, textStatus) {
                    // Onsuccess
                });
            });

            /** upload hình ảnh hướng dẫn viên **/
            $('#edit-image-guide').change(function () {
                var data = new FormData();
                data.append('Image', $('#edit-image-guide')[0].files[0]);

                var ajaxRequest = $.ajax({
                    type: "POST",
                    url: 'TourOtherTab/UploadImage',
                    contentType: false,
                    processData: false,
                    data: data
                });

                ajaxRequest.done(function (xhr, textStatus) {
                    // Onsuccess
                });
            });

        }
    });
}

/** xóa hướng dẫn viên **/
function deleteGuide(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/TourOtherTab/DeleteGuide',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            alert("Xóa dữ liệu thành công!!!");
            $("#huongdanvien").html(data);
        }
    });
}

/** upload tài liệu hướng dẫn viên **/
$('#insert-file-guide').change(function () {
    var data = new FormData();
    var totalFiles = document.getElementById("insert-file-guide").files.length;
    for (var i = 0; i < totalFiles; i++) {
        var file = document.getElementById("insert-file-guide").files[i];
        data.append('File', file);
    }

    var ajaxRequest = $.ajax({
        type: "POST",
        url: 'TourOtherTab/UploadMultipleFile',
        contentType: false,
        processData: false,
        data: data
    });

    ajaxRequest.done(function (xhr, textStatus) {
        // Onsuccess
    });
});

/** upload hình ảnh hướng dẫn viên **/
$('#insert-image-guide').change(function () {
    var data = new FormData();
    data.append('Image', $('#insert-image-guide')[0].files[0]);

    var ajaxRequest = $.ajax({
        type: "POST",
        url: 'TourOtherTab/UploadImage',
        contentType: false,
        processData: false,
        data: data
    });

    ajaxRequest.done(function (xhr, textStatus) {
        // Onsuccess
    });
});

function checkCodeContract() {
    var dataPost = { code: $("#CodeContract").val() };
    $.ajax({
        type: "POST",
        url: '/CustomerOtherTab/CheckCodeContract',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            if (data == 0) {
                $("#CodeContract").val('');
                $("#CodeContract").focus();
                alert('Trùng code hợp đồng');
            }
        }
    });
}

/* thêm mới báo giá */
function btnCreateCustomer() {
    if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
        alert("Vui lòng chọn 1 tour!");
    }
    else {
        var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };

        $.ajax({
            type: "POST",
            url: '/TourManage/GetIdTour',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                $.ajax({
                    type: "POST",
                    url: '/TourOtherTab/AddCustomer',
                    data: JSON.stringify(dataPost),
                    contentType: "application/json; charset=utf-8",
                    dataType: "html",
                    success: function (value) {
                        $("#info-data-customer").html(value);
                        $('.dataTable3').dataTable({
                            order: [],
                            columnDefs: [{ orderable: false, targets: [0] }]
                        });
                        $(".dataTable3").dataTable().columnFilter({
                            sPlaceHolder: "head:after",
                            aoColumns: [null,
                                        { type: "text" },
                                        { type: "text" },
                                        { type: "text" },
                                        { type: "text" },
                                        { type: "text" },
                                        { type: "text" },
                                        { type: "text" }]
                        });
                        $("#tableCustomer").on("change", ".checkAddCustomer", function () {
                            var ItemID = $(this).val();
                            var currentlistItemID = $("#listItemIdAddCus").val();
                            var stringBranchID = "";
                            if ($(this).prop('checked')) {
                                currentlistItemID += ItemID + ",";
                                $("#listItemIdAddCus").val(currentlistItemID);
                            } else {
                                $("#listItemIdAddCus").val(currentlistItemID.replace(ItemID + ",", ""));
                            }
                        });
                        $("#btnLuuAddCustomer").on("click", function () {
                            if ($("#listItemIdAddCus").val() == "") {
                                alert("Vui lòng chọn khách hàng đi tour!");
                                return false;
                            }
                            $("#formAddCustomer").submit();
                        });
                        $("#modal-add-customer").modal("show");
                        $("#tableCustomer").on("change", "#allcustomer", function () {
                            var $this = $(this);
                            $("#listItemIdAddCus").val('');
                            var currentlistItemID = $("#listItemIdAddCus").val();
                            var ItemID = "";
                            if ($this.prop("checked")) {
                                $(".checkAddCustomer").each(function () {
                                    ItemID = $(this).val();
                                    if ($(this).parent().hasClass('text-danger') == false) {
                                        $(this).prop("checked", true);
                                        currentlistItemID += ItemID + ",";
                                        $("#listItemIdAddCus").val(currentlistItemID);
                                    }

                                });
                            } else {
                                $(".checkAddCustomer").prop("checked", false);
                                $("#listItemIdAddCus").val("");
                            }
                        });
                    }
                });
            }
        });
    }
}

function OnFailureCreateCustomer() {
    alert("Lỗi!");
    $("#modal-add-customer").modal("hide");
}

function OnSuccessCreateCustomer() {
    alert("Đã lưu!");
    $("#modal-add-customer").modal("hide");
}

// tính tổng tiền trong công nợ khách hàng
function calTotalLiquidation() {
    var TotalContract = parseInt($("#EcnkhTong").val().replace('.','')) || 0;
    var TotalReturn = parseInt($("#Edit-TotalReturn").val().replace('.', '')) || 0;
    var CountService = parseInt($("#CountService").val().replace('.', '')) || 0;
    var txtTotalPrice = 0;
    for (var i = 1; i <= CountService; i++) {
        var txtQuantityS = parseInt($("#txtQuantityS" + i).val().replace('.', '')) || 0;
        var txtUnitPriceS = parseInt($("#txtUnitPriceS" + i).val().replace('.', '')) || 0;
        console.log(txtQuantityS * txtUnitPriceS);
        txtTotalPrice += (txtQuantityS * txtUnitPriceS);
    }
    $("#Edit-TotalLiquidation").val(TotalContract + TotalReturn + txtTotalPrice);
}
