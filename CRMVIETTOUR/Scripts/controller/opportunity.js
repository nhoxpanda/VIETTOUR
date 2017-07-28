
$('a.toggle-vis').on('click', function (e) {
    e.preventDefault();
    if ($(this).hasClass('selected')) {
        $(this).removeClass('selected');
    }
    else {
        $(this).addClass('selected');
    }
    // Get the column API object
    var column = table.column($(this).attr('data-column'));
    // Toggle the visibility
    column.visible(!column.visible());
});

CKEDITOR.replace("insert-note");
$("#insert-customer").select2();
$("#insert-status").select2();
$("#ddlKyBaoCao").select2();
$("#ddlGroup").select2();
$("#ddlStatus").select2();
$("#insert-group").select2();
$("#insert-formcontact").select2();

$("#btnEdit").click(function () {
    var dataPost = {
        id: $("input[type='checkbox']:checked").val()
    };

    $.ajax({
        type: "POST",
        url: '/OpportunityManage/Edit',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $("#edit-opportunity").html(data);
            CKEDITOR.replace("edit-note");
            $("#edit-customer").select2();
            $("#edit-status").select2();
            $("#edit-group").select2();
            $("#edit-formcontact").select2();
            $("#modal-edit-opportunity").modal("show");
            $("#edit-status").change(function () {
                var dataPost = {
                    id: $("#edit-status").val()
                };
                $.ajax({
                    type: "POST",
                    url: '/OpportunityManage/GetPercentByStatus',
                    data: JSON.stringify(dataPost),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $("#txtEPercent").val(data);
                    }
                });
            })
        }
    });
});

$("#ddlKyBaoCao").change(function () {
    var dataPost = {
        id: $("#ddlKyBaoCao").val()
    };
    $.ajax({
        type: "POST",
        url: '/ReportsManage/GetStartEndDate',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("#startEndDate").html(data);
        }
    });
})

functionDataTable();

function functionDataTable() {
    var table = $('.dataTable').DataTable({
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
                    { type: "text" },
                    { type: "text" }]
    });

    $("#tableDictionary").on("change", ".cbItem", function () {
        var ItemID = $(this).val();
        var currentlistItemID = $("#listItemId").val();
        var stringBranchID = "";
        if ($(this).prop('checked')) {
            currentlistItemID += ItemID + ",";
            $("#listItemId").val(currentlistItemID);
        } else {
            $("#listItemId").val(currentlistItemID.replace(ItemID + ",", ""));
        }
    });

    $("#tableDictionary").on("change", "#allcb", function () {
        var $this = $(this);
        $("#listItemId").val('');
        var currentlistItemID = $("#listItemId").val();
        var ItemID = "";
        if ($this.prop("checked")) {
            $(".cbItem").each(function () {
                ItemID = $(this).val();
                if ($(this).parent().hasClass('text-danger') == false) {
                    $(this).prop("checked", true);
                    currentlistItemID += ItemID + ",";
                    $("#listItemId").val(currentlistItemID);
                }
            });
        } else {
            $(".cbItem").prop("checked", false);
            $("#listItemId").val("");
        }
    });

    /** Xoa du lieu **/
    $("#btnRemove").on("click", function () {
        if ($("#listItemId").val() == "") {
            alert("Vui lòng chọn mục cần xóa !");
            return false;
        }
        var $this = $(this);
        var $tableWrapper = $("#tableDictionary-Wrapper");
        var $table = $("#tableDictionary");

        DeleteSelectedItem($this, $tableWrapper, $table, function (data) { });
        return false;
    });

    function DeleteSelectedItem(selector, tableWrapper, table, callBack) {
        if (!confirm("Bạn thực sự muốn xóa những mục đã chọn ?")) {
            return false;
        }
        var $form = selector.next("form");
        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize(),
        };

        tableWrapper.append("<div class='layer'></div>");

        $.ajax(options).done(function (data) {
            tableWrapper.find(".layer").remove();
            if (data.Succeed) {
                alert(data.Message);
                if (data.IsPartialView) {
                    table.replaceWith(data.View);
                }
                else {
                    if (data.RedirectTo != null && data.RedirectTo != "") {
                        window.location.href = data.RedirectTo;
                    }
                }
            }
            else {
                alert(data.Message);
            }
        });
    }

    /** chọn từng dòng để hiển thị thông tin chi tiết dưới các tab **/
    $("table#tableDictionary").delegate("tr", "click", function (e) {
        $('tr').not(this).removeClass('oneselected');
        $(this).toggleClass('oneselected');
        var tab = $(".tab-content").find('.active').data("id");
        var dataPost = { id: $(this).find("input[type='checkbox']").val() };
        switch (tab) {
            case 'thongtinchitiet':
                $.ajax({
                    type: "POST",
                    url: '/OpportunityTabInfo/InfoThongTinChiTiet',
                    data: JSON.stringify(dataPost),
                    contentType: "application/json; charset=utf-8",
                    dataType: "html",
                    success: function (data) {
                        $("#thongtinchitiet").html(data);
                    }
                });
                break;
            case 'lichhen':
                $.ajax({
                    type: "POST",
                    url: '/OpportunityTabInfo/InfoLichHen',
                    data: JSON.stringify(dataPost),
                    contentType: "application/json; charset=utf-8",
                    dataType: "html",
                    success: function (data) {
                        $("#lichhen").html(data);
                    }
                });
                break;
            case 'nhatkyxuly':
                $.ajax({
                    type: "POST",
                    url: '/OpportunityTabInfo/InfoNhatKyXuLy',
                    data: JSON.stringify(dataPost),
                    contentType: "application/json; charset=utf-8",
                    dataType: "html",
                    success: function (data) {
                        $("#nhatkyxuly").html(data);
                    }
                });
                break;
            case 'nhatkygiaodich':
                $.ajax({
                    type: "POST",
                    url: '/OpportunityTabInfo/InfoNhatKyGiaoDich',
                    data: JSON.stringify(dataPost),
                    contentType: "application/json; charset=utf-8",
                    dataType: "html",
                    success: function (data) {
                        $("#nhatkygiaodich").html(data);
                    }
                });
                break;
            case 'nguoilienhe':
                $.ajax({
                    type: "POST",
                    url: '/OpportunityTabInfo/InfoNguoiLienHe',
                    data: JSON.stringify(dataPost),
                    contentType: "application/json; charset=utf-8",
                    dataType: "html",
                    success: function (data) {
                        $("#nguoilienhe").html(data);
                    }
                });
                break;
            case 'doithu':
                $.ajax({
                    type: "POST",
                    url: '/OpportunityTabInfo/InfoDoiThu',
                    data: JSON.stringify(dataPost),
                    contentType: "application/json; charset=utf-8",
                    dataType: "html",
                    success: function (data) {
                        $("#doithu").html(data);
                    }
                });
                break;
            case 'tailieumau':
                $.ajax({
                    type: "POST",
                    url: '/OpportunityTabInfo/InfoTaiLieuMau',
                    data: JSON.stringify(dataPost),
                    contentType: "application/json; charset=utf-8",
                    dataType: "html",
                    success: function (data) {
                        $("#tailieumau").html(data);
                    }
                });
                break;
            case 'yeucau':
                $.ajax({
                    type: "POST",
                    url: '/OpportunityTabInfo/InfoYeuCauPhanHoi',
                    data: JSON.stringify(dataPost),
                    contentType: "application/json; charset=utf-8",
                    dataType: "html",
                    success: function (data) {
                        $("#yeucau").html(data);
                    }
                });
                break;
            case 'lichsulienhe':
                $.ajax({
                    type: "POST",
                    url: '/OpportunityTabInfo/InfoLichSuLienHe',
                    data: JSON.stringify(dataPost),
                    contentType: "application/json; charset=utf-8",
                    dataType: "html",
                    success: function (data) {
                        $("#lichsulienhe").html(data);
                    }
                });
                break;
        }
    });

    /** click chọn từng tab -> hiển thị thông tin **/
    $("#tabthongtinchitiet").click(function () {
        if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
            alert("Vui lòng chọn 1 cơ hội!");
        }
        else {
            var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };
            $.ajax({
                type: "POST",
                url: '/OpportunityTabInfo/InfoThongTinChiTiet',
                data: JSON.stringify(dataPost),
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                success: function (data) {
                    $("#thongtinchitiet").html(data);
                }
            });
        }
    });

    $("#tablichhen").click(function () {
        if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
            alert("Vui lòng chọn 1 cơ hội!");
        }
        else {
            var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };
            $.ajax({
                type: "POST",
                url: '/OpportunityTabInfo/InfoLichHen',
                data: JSON.stringify(dataPost),
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                success: function (data) {
                    $("#lichhen").html(data);
                }
            });
        }
    });

    $("#tablichsulienhe").click(function () {
        if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
            alert("Vui lòng chọn 1 cơ hội!");
        }
        else {
            var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };
            $.ajax({
                type: "POST",
                url: '/OpportunityTabInfo/InfoLichSuLienHe',
                data: JSON.stringify(dataPost),
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                success: function (data) {
                    $("#lichsulienhe").html(data);
                }
            });
        }
    });

    $("#tabnhatkyxuly").click(function () {
        if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
            alert("Vui lòng chọn 1 cơ hội!");
        }
        else {
            var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };
            $.ajax({
                type: "POST",
                url: '/OpportunityTabInfo/InfoNhatKyXuLy',
                data: JSON.stringify(dataPost),
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                success: function (data) {
                    $("#nhatkyxuly").html(data);
                }
            });
        }
    });

    $("#tabtailieumau").click(function () {
        if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
            alert("Vui lòng chọn 1 cơ hội!");
        }
        else {
            var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };
            $.ajax({
                type: "POST",
                url: '/OpportunityTabInfo/InfoTaiLieuMau',
                data: JSON.stringify(dataPost),
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                success: function (data) {
                    $("#tailieumau").html(data);
                }
            });
        }
    });

    $("#tabnhatkygiaodich").click(function () {
        if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
            alert("Vui lòng chọn 1 cơ hội!");
        }
        else {
            var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };
            $.ajax({
                type: "POST",
                url: '/OpportunityTabInfo/InfoNhatKyGiaoDich',
                data: JSON.stringify(dataPost),
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                success: function (data) {
                    $("#nhatkygiaodich").html(data);
                }
            });
        }
    });

    $("#tabnguoilienhe").click(function () {
        if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
            alert("Vui lòng chọn 1 cơ hội!");
        }
        else {
            var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };
            $.ajax({
                type: "POST",
                url: '/OpportunityTabInfo/InfoNguoiLienHe',
                data: JSON.stringify(dataPost),
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                success: function (data) {
                    $("#nguoilienhe").html(data);
                }
            });
        }
    });

    $("#tabdoithu").click(function () {
        if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
            alert("Vui lòng chọn 1 cơ hội!");
        }
        else {
            var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };
            $.ajax({
                type: "POST",
                url: '/OpportunityTabInfo/InfoDoiThu',
                data: JSON.stringify(dataPost),
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                success: function (data) {
                    $("#doithu").html(data);
                }
            });
        }
    });

    $("#tabyeucau").click(function () {
        if ($("table#tableDictionary").find('tr.oneselected').length === 0) {
            alert("Vui lòng chọn 1 cơ hội!");
        }
        else {
            var dataPost = { id: $("table#tableDictionary").find('tr.oneselected').find("input[type='checkbox']").val() };
            $.ajax({
                type: "POST",
                url: '/OpportunityTabInfo/InfoYeuCauPhanHoi',
                data: JSON.stringify(dataPost),
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                success: function (data) {
                    $("#yeucau").html(data);
                }
            });
        }
    });
}

/** success ajax form **/
function OnSuccessCustomerFile() {
    $("#modal-insert-document").modal("hide");
    $("#modal-edit-document").modal("hide");
    $('form').trigger("reset");
    CKupdate();
}

/** failure ajax form **/
function OnFailureCustomerFile() {
    alert("Lỗi, vui lòng kiểm tra lại!");
    $("#modal-insert-document").modal("hide");
    $("#modal-edit-document").modal("hide");
    $('form').trigger("reset");
    CKupdate();
}

/**  filter **/
$("#btnSearch").click(function () {
    var dataPost = {
        dateFrom: $("#txtStartDate").val(),
        dateTo: $("#txtEndDate").val(),
        status: $("#ddlStatus").val(),
        group: $("#ddlGroup").val(),
        percentFrom: $("#txtFromPercent").val(),
        percentTo: $("#txtToPercent").val(),
    };
    $.ajax({
        type: "POST",
        url: '/OpportunityManage/Filter',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            $("#data-opportunity").html(data);
            functionDataTable();
        }
    });
});

$("#insert-status").change(function () {
    var dataPost = {
        id: $("#insert-status").val()
    };
    $.ajax({
        type: "POST",
        url: '/OpportunityManage/GetPercentByStatus',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("#txtPercent").val(data);
        }
    });
})

//fileImport
$('#fileImport').change(function () {
    var data = new FormData();
    data.append('FileNameOpportunity', $('#fileImport')[0].files[0]);

    var ajaxRequest = $.ajax({
        type: "POST",
        url: 'OpportunityManage/ImportFile',
        contentType: false,
        processData: false,
        data: data
    });

    ajaxRequest.done(function (xhr, textStatus) {
        // Onsuccess
    });
    ajaxRequest.success(function (data) {
        $("#listItemIdI").val("");
        $("#import-data-customer").html(data);
    })
});

/********* thêm mới khách hàng *********/ 

function OnSuccessCustomer() {
    $("#modal-insert-customer").modal("hide");
    $("#modal-insert-customer").select2();
}

function OnFailureCustomer() {
    $("#modal-insert-customer").modal("hide");
    $("#modal-insert-customer").select2();
}