CKEDITOR.replace("insert-competitor-advantage");
CKEDITOR.replace("insert-competitor-disadvantage");
CKEDITOR.replace("insert-document-note");
CKEDITOR.replace("insert-transaction-note");
CKEDITOR.replace("insert-request-note");
CKEDITOR.replace("insert-appointment-note");
CKEDITOR.replace("insert-history-note");
/********** đối thủ **********/
function createCompetitor() {
    if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
        alert("Vui lòng chọn 1 cơ hội!");
    }
    else {
        var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };

        $.ajax({
            type: "POST",
            url: '/OpportunityManage/GetIdOpportunity',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                $("#modal-insert-competitor").modal("show");
            }
        });
    }
}
function deleteCompetitor(id) {
    if (confirm('Bạn thực sự muốn xóa mục này ?')) {
        var dataPost = { id: id };
        $.ajax({
            type: "POST",
            url: '/OpportunityOtherTab/DeleteCompetitor',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                alert("Xóa dữ liệu thành công!!!");
                $("#doithu").html(data);
            }
        });
    }
}
function updateCompetitor(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/OpportunityOtherTab/EditCompetitor',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $("#info-data-competitor").html(data);
            CKEDITOR.replace("edit-competitor-advantage");
            CKEDITOR.replace("edit-competitor-disadvantage");
            $("#modal-edit-competitor").modal("show");
        }
    });
}
/********** lịch hẹn **********/
function createAppointment() {
    if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
        alert("Vui lòng chọn 1 cơ hội!");
    }
    else {
        var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };

        $.ajax({
            type: "POST",
            url: '/OpportunityManage/GetIdOpportunity',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                $("#insert-ngayhen-lichhen").val(moment(new Date()).format("YYYY-MM-DD") + "T08:30");
                $("#insert-tour-lichhen").select2();
                $("#insert-program-lichhen").select2();
                $("#insert-task-lichhen").select2();
                $("#insert-status-lichhen").select2();
                $("#insert-service-lichhen").select2();
                $("#insert-partner-lichhen").select2();
                $("#insert-staff-customer").select2();
                $("#insert-type-lichhen").select2();
                $("#insert-nhactruoc-lichhen").select2();
                $("#insert-laplai-lichhen").select2();
                $("#modal-insert-appointment").modal("show");
                //
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
                    $.getJSON('/CustomerOtherTab/LoadPartner/' + $('#insert-service-lichhen').val(), function (data) {
                        var items = '<option value=' + 0 + '>-- Chọn đối tác --</option>';
                        $.each(data, function (i, ward) {
                            items += "<option value='" + ward.Value + "'>" + ward.Text + "</option>";
                        });
                        $('#insert-partner-lichhen').html(items);
                    });
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
                    $.getJSON('/CustomerOtherTab/LoadPartner/' + $('#insert-service-lichhen').val(), function (data) {
                        var items = '<option value=' + 0 + '>-- Chọn đối tác --</option>';
                        $.each(data, function (i, ward) {
                            items += "<option value='" + ward.Value + "'>" + ward.Text + "</option>";
                        });
                        $('#insert-partner-lichhen').html(items);
                    });
                });
            }
        });
    }
}
function deleteAppointment(id) {
    if (confirm('Bạn thực sự muốn xóa mục này ?')) {
        var dataPost = { id: id };
        $.ajax({
            type: "POST",
            url: '/OpportunityOtherTab/DeleteAppointment',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                alert("Xóa dữ liệu thành công!!!");
                $("#lichhen").html(data);
            }
        });
    }
}
function updateAppointment(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/OpportunityOtherTab/EditAppointment',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $("#info-data-appointment").html(data);
            CKEDITOR.replace("edit-appointment-note");
            $("#edit-tour-lichhen").select2();
            $("#edit-program-lichhen").select2();
            $("#edit-task-lichhen").select2();
            $("#edit-status-lichhen").select2();
            $("#edit-service-lichhen").select2();
            $("#edit-partner-lichhen").select2();
            $("#edit-staff-customer").select2();
            $("#edit-type-lichhen").select2();
            $("#edit-nhactruoc-lichhen").select2();
            $("#edit-laplai-lichhen").select2();
            $("#modal-edit-appointment").modal("show");
            //
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
                $.getJSON('/CustomerOtherTab/LoadPartner/' + $('#edit-service-lichhen').val(), function (data) {
                    var items = '<option value=' + 0 + '>-- Chọn đối tác --</option>';
                    $.each(data, function (i, ward) {
                        items += "<option value='" + ward.Value + "'>" + ward.Text + "</option>";
                    });
                    $('#edit-partner-lichhen').html(items);
                });
            });
        }
    });
}
/********** người liên hệ **********/
function createContact() {
    if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
        alert("Vui lòng chọn 1 cơ hội!");
    }
    else {
        var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };

        $.ajax({
            type: "POST",
            url: '/OpportunityManage/GetIdOpportunity',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                $("#insert-quydanh-contact").select2();
                $("#insert-address-contact").select2();
                $("#modal-insert-contact").modal("show");
            }
        });
    }
}
function deleteContact(id) {
    if (confirm('Bạn thực sự muốn xóa mục này ?')) {
        var dataPost = { id: id };
        $.ajax({
            type: "POST",
            url: '/OpportunityOtherTab/DeleteContact',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                alert("Xóa dữ liệu thành công!!!");
                $("#nguoilienhe").html(data);
            }
        });
    }
}
function updateContact(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/OpportunityOtherTab/EditContact',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $("#info-data-contact").html(data);
            $("#edit-quydanh-contact").select2();
            $("#edit-address-contact").select2();
            $("#modal-edit-contact").modal("show");
        }
    });
}
/********** nhật ký giao dịch **********/
function createTransaction() {
    if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
        alert("Vui lòng chọn 1 cơ hội!");
    }
    else {
        var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };

        $.ajax({
            type: "POST",
            url: '/OpportunityManage/GetIdOpportunity',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                $("#insert-request-type").select2();
                $("#modal-insert-transaction").modal("show");
            }
        });
    }
}
function deleteTransaction(id) {
    if (confirm('Bạn thực sự muốn xóa mục này ?')) {
        var dataPost = { id: id };
        $.ajax({
            type: "POST",
            url: '/OpportunityOtherTab/DeleteTransaction',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                alert("Xóa dữ liệu thành công!!!");
                $("#nhatkygiaodich").html(data);
            }
        });
    }
}
function updateTransaction(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/OpportunityOtherTab/EditTransaction',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $("#info-data-transaction").html(data);
            $("#edit-request-type").select2();
            CKEDITOR.replace("edit-transaction-note");
            $("#modal-edit-transaction").modal("show");
        }
    });
}
/********** tài liệu mẫu **********/
function createDocument() {
    if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
        alert("Vui lòng chọn 1 cơ hội!");
    }
    else {
        var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };

        $.ajax({
            type: "POST",
            url: '/OpportunityManage/GetIdOpportunity',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                $("#insert-document-type").select2();
                $("#insert-document-tag").select2();
                $("#modal-insert-document").modal("show");
                $('#insert-file-opportunity').change(function () {
                    var data = new FormData();
                    data.append('FileName', $('#insert-file-opportunity')[0].files[0]);
                    var ajaxRequest = $.ajax({
                        type: "POST",
                        url: 'OpportunityOtherTab/UploadFileOpportunity',
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
function deleteDocument(id) {
    if (confirm('Bạn thực sự muốn xóa mục này ?')) {
        var dataPost = { id: id };
        $.ajax({
            type: "POST",
            url: '/OpportunityOtherTab/DeleteDocument',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                alert("Xóa dữ liệu thành công!!!");
                $("#tailieumau").html(data);
            }
        });
    }
}
function updateDocument(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/OpportunityOtherTab/EditInfoDocument',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $("#info-data-document").html(data);
            $("#edit-document-type").select2();
            $("#edit-document-tag").select2();
            CKEDITOR.replace("edit-document-note");
            $("#modal-edit-document").modal("show");
            $('#edit-file-opportunity').change(function () {
                var data = new FormData();
                data.append('FileName', $('#edit-file-opportunity')[0].files[0]);

                var ajaxRequest = $.ajax({
                    type: "POST",
                    url: 'OpportunityOtherTab/UploadFileOpportunity',
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
/********** yêu cầu phản hồi **********/
function createRequest() {
    if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
        alert("Vui lòng chọn 1 cơ hội!");
    }
    else {
        var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };

        $.ajax({
            type: "POST",
            url: '/OpportunityManage/GetIdOpportunity',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                $("#modal-insert-request").modal("show");
            }
        });
    }
}
function deleteRequest(id) {
    if (confirm('Bạn thực sự muốn xóa mục này ?')) {
        var dataPost = { id: id };
        $.ajax({
            type: "POST",
            url: '/OpportunityOtherTab/DeleteRequest',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                alert("Xóa dữ liệu thành công!!!");
                $("#yeucau").html(data);
            }
        });
    }
}
function updateRequest(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/OpportunityOtherTab/EditRequest',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $("#info-data-request").html(data);
            CKEDITOR.replace("edit-request-note");
            $("#modal-edit-request").modal("show");
        }
    });
}
/********** lịch sử liên hệ **********/
function createHistory() {
    if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
        alert("Vui lòng chọn 1 cơ hội!");
    }
    else {
        var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };

        $.ajax({
            type: "POST",
            url: '/OpportunityManage/GetIdOpportunity',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                $("#insert-type-lienhe").select2();
                $("#modal-insert-history").modal("show");
            }
        });
    }
}
function deleteHistory(id) {
    if (confirm('Bạn thực sự muốn xóa mục này ?')) {
        var dataPost = { id: id };
        $.ajax({
            type: "POST",
            url: '/OpportunityOtherTab/DeleteHistory',
            data: JSON.stringify(dataPost),
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                alert("Xóa dữ liệu thành công!!!");
                $("#lichsulienhe").html(data);
            }
        });
    }
}
function updateHistory(id) {
    var dataPost = { id: id };
    $.ajax({
        type: "POST",
        url: '/OpportunityOtherTab/EditHistory',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $("#info-data-history").html(data);
            $("#edit-type-lienhe").select2();
            CKEDITOR.replace("edit-history-note");
            $("#modal-edit-history").modal("show");
        }
    });
}
/********** thành công, thất bại **********/
function OnSuccessOpportunity() {
    alert("Đã lưu!");
    $("#modal-insert-competitor").modal("hide");
    $("#modal-insert-appointment").modal("hide");
    $("#modal-insert-contact").modal("hide");
    $("#modal-insert-request").modal("hide");
    $("#modal-insert-transaction").modal("hide");
    $("#modal-insert-document").modal("hide");
    $("#modal-insert-history").modal("hide");
    $("#modal-edit-history").modal("hide");
    $("#modal-edit-competitor").modal("hide");
    $("#modal-edit-appointment").modal("hide");
    $("#modal-edit-contact").modal("hide");
    $("#modal-edit-request").modal("hide");
    $("#modal-edit-transaction").modal("hide");
    $("#modal-edit-document").modal("hide");
    $('form').trigger("reset");
    CKupdate();
}
function OnFailureOpportunity() {
    alert("Lỗi, vui lòng kiểm tra lại!");
    $("#modal-insert-competitor").modal("hide");
    $("#modal-insert-appointment").modal("hide");
    $("#modal-insert-contact").modal("hide");
    $("#modal-insert-request").modal("hide");
    $("#modal-insert-transaction").modal("hide");
    $("#modal-insert-document").modal("hide");
    $("#modal-insert-history").modal("hide");
    $("#modal-edit-history").modal("hide");
    $("#modal-edit-competitor").modal("hide");
    $("#modal-edit-appointment").modal("hide");
    $("#modal-edit-contact").modal("hide");
    $("#modal-edit-request").modal("hide");
    $("#modal-edit-transaction").modal("hide");
    $("#modal-edit-document").modal("hide");
    $('form').trigger("reset");
    CKupdate();
}