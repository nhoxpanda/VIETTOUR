$("#ddlid").select2();
$("#ddlidtag").select2();
$("#ddltype").select2();
$("#ddlstatus").select2();
$("#select-tour").select2();

$("#select-customer").select2();
$("#insert-country-visa").select2();
$("#insert-status-visa").select2();
$("#insert-type-visa").select2();

$("#select-staff").select2();
$("#insert-country-visastaff").select2();
$("#insert-status-visastaff").select2();
$("#insert-type-visastaff").select2();

$('.dataTable').DataTable({
    order: [],
    columnDefs: [{ orderable: false, targets: [0] }]
});

$(".dataTable").dataTable().columnFilter({
    sPlaceHolder: "head:after",
    aoColumns: [null,
                { type: "text" },
                { type: "text" },
                { type: "text" },
                { type: "text" },
                { type: "text" },
                { type: "text" },
                { type: "text" },
                { type: "text" }]
});

function filter() {
    var dataPost = {
        id: $("#ddlid").val(),
        idtag: $("#ddlidtag").val(),
        type: $("#ddltype").val(),
        status: $("#ddlstatus").val(),
        startDate: $("#txtstart").val(),
        endDate: $("#txtend").val()
    };
    $.ajax({
        type: "POST",
        url: '/ListVisaManage/FilterCustomerStaff',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $("#data-visa").html(data);

            $('.dataTable').DataTable({
                order: [],
                columnDefs: [{ orderable: false, targets: [0] }]
            });

            $(".dataTable").dataTable().columnFilter({
                sPlaceHolder: "head:after",
                aoColumns: [null,
                            { type: "text" },
                            { type: "text" },
                            { type: "text" },
                            { type: "text" },
                            { type: "text" },
                            { type: "text" },
                            { type: "text" },
                            { type: "text" }]
            });
            // kéo dài kích thước cột
            colResize();
        }
    });
}

$("#ddlid").change(function () {
    filter();
    $("#txtid").val($("#ddlid").val());
});

$("#ddlidtag").change(function () {
    filter();
    $("#txtidtag").val($("#ddlidtag").val());
});

$("#ddltype").change(function () {
    filter();
    $("#txttype").val($("#ddltype").val());
});

$("#ddlstatus").change(function () {
    filter();
    $("#txtstatus").val($("#ddlstatus").val());
});

$("#txtstart").change(function () {
    filter();
    $("#txtstartDate").val($("#txtstart").val());
});

$("#txtend").change(function () {
    filter();
    $("#txtendDate").val($("#txtend").val());
});

/** check visa **/
$("#insert-visa-customer").change(function () {
    var dataPost = {
        text: $("#insert-visa-customer").val()
    };
    $.ajax({
        type: "POST",
        url: '/CustomersManage/CheckVisa',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            if (data == "1") { // trùng
                alert("Dữ liệu trùng lắp! Vui lòng nhập lại!");
                    $("#insert-visa-customer").val('');
                    $("#insert-visa-customer").focus();
                
            }
        }
    });
});

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

/** sửa Visa **/
function editVisa(id, iscus){
    var dataPost = {
        id: id,
        iscus: iscus
    };
    $.ajax({
        type: 'POST',
        url: '/ListVisaManage/Edit',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $("#data-edit-visa").html(data);
            $("#edit-country-visa").select2();
            $("#edit-status-visa").select2();
            $("#edit-type-visa").select2();
            $("#modal-edit-visa").modal("show");
        }
    })
}

/** xóa Visa **/
function deleteVisa(id, iscus) {
    var dataPost = {
        id: id,
        iscus: iscus
    };
    $.ajax({
        type: 'POST',
        url: '/ListVisaManage/DeleteVisa',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $("#row" + id + iscus).hide();
        }
    })
}

function OnFailureListVisa() {
    $("#modal-edit-visa").modal('hide');
    alert("Lỗi!");
    window.location.href = '/ListVisaManage';
}

function OnSuccessListVisa() {
    $("#modal-edit-visa").modal('hide');
    window.location.href = '/ListVisaManage';
}

/*********** THÊM MỚI KHÁCH HÀNG TRONG VISA ***********/

/** check tên khách hàng cá nhân **/
$("#insert-detail-personal").change(function () {
    $("#insert-personal-name").val($("#insert-detail-personal :selected").text());
});

function OnSuccessVisa() {
    $("#modal-insert-customer").modal("hide");
    $("#select-customer").select2();
}
function OnFailureVisa() {
    $("#modal-insert-customer").modal("hide");
    $("#select-customer").select2();
}

$("#check-customer-company").change(function () {
    if ($(this).is(":checked"))
        $('#customer-company').attr('disabled', false);
    else
        $('#customer-company').attr('disabled', true);
})
/*** visa-passport ***/
$("#country-insert-cmnd").select2();
$("#country-insert-passport").select2();
/*** doanh nghiệp ***/
$("#insert-province-company").select2();
$("#insert-district-company").select2();
$("#insert-ward-company").select2();
$("#customer-nhomkh-company").select2();
$("#customer-nguonden-company").select2();
$("#edit-customer-company").select2();
$("#customer-quanly-company").select2();
$("#insert-detail-company").select2({
    tags: true
});
/*** cá nhân ***/
$("#insert-province-personal").select2();
$("#insert-district-personal").select2();
$("#insert-ward-personal").select2();
$("#customer-nghenghiep-personal").select2();
$("#customer-nguonden-personal").select2();
$("#customer-nhomkh-personal").select2();
$("#customer-quydanh").select2();
$("#customer-quanly-personal").select2();
$("#customer-company").select2();
$("#insert-nganhnghe-other").select2();
$("#insert-address-othercompany").select2();
$("#insert-detail-personal").select2({
    tags: true
});
/*** người liên hệ ***/
$("#customer-contact").select2();
$("#customer-quydanh-contact").select2();
$("#insert-address-contact").select2();
$("#country-insert-profilevisa").select2();

// tỉnh thành, quận huyện, phường xã
$("#insert-province-company").change(function () {
    $.getJSON('/Home/DistrictList?id=' + $('#insert-province-company').val(), function (data) {
        var items = '<option>Quận/Huyện</option>';
        $.each(data, function (i, gd) {
            items += "<option value='" + gd.Value + "'>" + gd.Text + "</option>";
        });
        $('#insert-district-company').html(items);
    });
})

$("#insert-district-company").change(function () {
    $.getJSON('/Home/WardList?id=' + $('#insert-district-company').val(), function (data) {
        var items = '<option>Phường/Xã</option>';
        $.each(data, function (i, gd) {
            items += "<option value='" + gd.Value + "'>" + gd.Text + "</option>";
        });
        $('#insert-ward-company').html(items);
    });
})

//

$("#insert-province-personal").change(function () {
    $.getJSON('/Home/DistrictList?id=' + $('#insert-province-personal').val(), function (data) {
        var items = '<option>Quận/Huyện</option>';
        $.each(data, function (i, gd) {
            items += "<option value='" + gd.Value + "'>" + gd.Text + "</option>";
        });
        $('#insert-district-personal').html(items);
    });
})

$("#insert-district-personal").change(function () {
    $.getJSON('/Home/WardList?id=' + $('#insert-district-personal').val(), function (data) {
        var items = '<option>Phường/Xã</option>';
        $.each(data, function (i, gd) {
            items += "<option value='" + gd.Value + "'>" + gd.Text + "</option>";
        });
        $('#insert-ward-personal').html(items);
    });
})

$("#dienthoai-canhan").change(function () {
    var dataPost = {
        text: $("#dienthoai-canhan").val()
    };
    $.ajax({
        type: "POST",
        url: '/CustomersManage/CheckPhone',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            if (data == "1") { // trùng
                alert("Dữ liệu trùng lắp! Vui lòng nhập lại!");
                    $("#dienthoai-canhan").val('');
                    $("#dienthoai-canhan").focus();
                
            }
        }
    });
});

$("#didong-canhan").change(function () {
    var dataPost = {
        text: $("#didong-canhan").val()
    };
    $.ajax({
        type: "POST",
        url: '/CustomersManage/CheckPhone',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            if (data == "1") { // trùng
                alert("Dữ liệu trùng lắp! Vui lòng nhập lại!");
                    $("#didong-canhan").val('');
                    $("#didong-canhan").focus();
                
            }
        }
    });
});