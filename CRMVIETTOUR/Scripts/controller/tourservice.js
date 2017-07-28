﻿function OnFailureTourService() {
    $('form').trigger("reset");
    CKupdate();
    alert('Lỗi!');
    $("#modal-insert-event").modal("hide");
}

function OnSuccessTourService() {
    $('form').trigger("reset");
    CKupdate();
    alert('Đã lưu!');
    $("#modal-insert-event").modal("hide");
}

$(document).ready(function () {
    $("#selectRestaurant").click(function () {
        $("#modal-insert-services-tour").modal("hide");
        /***** popup insert nhà hàng *****/
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
                    $("#modal-insert-services-tour").modal("hide");
                    $("#modal-insert-restaurant").modal("show");
                    /*** upload file restaurant đầu tiên ***/
                    $('#RestaurantDocument1').change(function () {
                        var data = new FormData();
                        data.append('RestaurantDocument', $('#RestaurantDocument1')[0].files[0]);
                        data.append('id', 1);

                        var ajaxRequest = $.ajax({
                            type: "POST",
                            url: 'TourService/UploadFileRestaurant',
                            contentType: false,
                            processData: false,
                            data: data
                        });

                        ajaxRequest.done(function (xhr, textStatus) {
                            // Onsuccess
                        });
                    });

                    $('#RestaurantName1').change(function () {
                        $.getJSON('/TourService/LoadPartner/' + $('#RestaurantName1').val(), function (data) {
                            $('#RestaurantAddress1').val(data.Address);
                            $('#RestaurantCode1').val(data.Code);
                            $('#NguoiLienHe1').val(data.StaffContact);
                            $('#DienThoai1').val(data.Phone);
                        });
                    });

                }
            });
        }
    })

    $("#selectHotel").click(function () {
        $("#modal-insert-services-tour").modal("hide");
        /***** popup insert khách sạn *****/
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
                    $("#modal-insert-services-tour").modal("hide");
                    $("#modal-insert-hotel").modal("show");

                    $('#hotel-tour1').change(function () {
                        $.getJSON('/TourService/LoadPartner/' + $('#hotel-tour1').val(), function (data) {
                            $('#code-hotel1').val(data.Code);
                            $('#nguoi-lien-he-hotel1').val(data.StaffContact);
                            $('#phone-hotel1').val(data.Phone);
                        });
                    });

                }
            });
        }
    })

    $("#selectTransport").click(function () {
        $("#modal-insert-services-tour").modal("hide");
        /***** popup insert vận chuyển *****/
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
                    $("#modal-insert-services-tour").modal("hide");
                    $("#modal-insert-transport").modal("show");
                    /******** upload file đầu tiên *******/
                    $('#RestaurantDocument1').change(function () {
                        var data = new FormData();
                        data.append('TransportDocument', $('#file-transport1')[0].files[0]);
                        data.append('id', 1);

                        var ajaxRequest = $.ajax({
                            type: "POST",
                            url: 'TourService/UploadFileTransport',
                            contentType: false,
                            processData: false,
                            data: data
                        });

                        ajaxRequest.done(function (xhr, textStatus) {
                            // Onsuccess
                        });
                    });

                    $('#name-transport1').change(function () {
                        $.getJSON('/TourService/LoadPartner/' + $('#name-transport1').val(), function (data) {
                            $('#code-transport1').val(data.Code);
                            $('#nguoilienhe-transport1').val(data.StaffContact);
                            $('#phone-transport1').val(data.Phone);
                        });
                    });

                }
            });
        }
    })

    $("#selectPlane").click(function () {
        $("#modal-insert-services-tour").modal("hide");
        /***** popup insert vé máy bay *****/
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
                    $("#modal-insert-services-tour").modal("hide");
                    $("#modal-insert-plane").modal("show");
                    /*** upload file restaurant đầu tiên ***/
                    $('#file-deadline-plane11').change(function () {
                        var data = new FormData();
                        data.append('FileNamePlane', $('#file-deadline-plane11')[0].files[0]);
                        data.append('id', 1);

                        var ajaxRequest = $.ajax({
                            type: "POST",
                            url: 'TourService/UploadFilePlane',
                            contentType: false,
                            processData: false,
                            data: data
                        });

                        ajaxRequest.done(function (xhr, textStatus) {
                            // Onsuccess
                        });
                    });
                    $('#hang-plane1').change(function () {
                        $.getJSON('/TourService/LoadPartner/' + $('#hang-plane1').val(), function (data) {
                            $('#code-plane1').val(data.Code);
                            $('#contacter-plane1').val(data.StaffContact);
                            $('#contacter-phone-plane1').val(data.Phone);
                        });
                    });


                }
            });
        }
    })

    $("#selectEvent").click(function () {
        /***** popup insert sự kiện *****/
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
                    $("#modal-insert-services-tour").modal("hide");
                    $("#modal-insert-event").modal("show");
                    /*** upload file event đầu tiên ***/
                    $('#insert-file-event1').change(function () {
                        var data = new FormData();
                        data.append('FileNameEvent', $('#insert-file-event1')[0].files[0]);
                        data.append('id', 1);

                        var ajaxRequest = $.ajax({
                            type: "POST",
                            url: 'TourService/UploadFileEvent',
                            contentType: false,
                            processData: false,
                            data: data
                        });

                        ajaxRequest.done(function (xhr, textStatus) {
                            // Onsuccess
                        });
                    });
                    $('#insert-company-event1').change(function () {
                        $.getJSON('/TourService/LoadPartner/' + $('#insert-company-event1').val(), function (data) {
                            $('#insert-code-event1').val(data.Code);
                            $('#insert-contact-event1').val(data.StaffContact);
                            $('#insert-phone-event1').val(data.Phone);
                        });
                    });
                }
            });
        }
    })

    $("#selectLandtour").click(function () {
        /***** popup insert sự kiện *****/
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
                    $("#modal-insert-services-tour").modal("hide");
                    $("#modal-insert-landtour").modal("show");
                    /*** upload file event đầu tiên ***/
                    $('#insert-file-landtour1').change(function () {
                        var data = new FormData();
                        data.append('FileNameEvent', $('#insert-file-landtour1')[0].files[0]);
                        data.append('id', 1);

                        var ajaxRequest = $.ajax({
                            type: "POST",
                            url: 'TourService/UploadFileLandtour',
                            contentType: false,
                            processData: false,
                            data: data
                        });

                        ajaxRequest.done(function (xhr, textStatus) {
                            // Onsuccess
                        });
                    });
                    $('#insert-company-landtour1').change(function () {
                        $.getJSON('/TourService/LoadPartner/' + $('#insert-company-landtour1').val(), function (data) {
                            $('#insert-code-landtour1').val(data.Code);
                            $('#insert-contact-landtour1').val(data.StaffContact);
                            $('#insert-phone-landtour1').val(data.Phone);
                        });
                    });
                }
            });
        }
    })
})

/***** xóa dịch vụ *****/
function deleteService(tourid, optionid) {
    var dataPost = { tourid: tourid, optionid: optionid };
    $.ajax({
        type: "POST",
        url: '/TourService/DeleteService',
        data: JSON.stringify(dataPost),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            alert("Xóa dữ liệu thành công!!!");
            $("#dichvu").html(data);
        },
        error: function (data) {
            alert("Không xóa được!!!");
            $("#dichvu").html(data);
        }
    });
}

///OtherPartner
$("#insert-currency-otherpartner1").select2();
$("#insert-company-otherpartner1").select2();
$("#deadline-status-otherpartner1").select2();
$("#deadline-currency-otherpartner1").select2();
/******** duplicate *******/
function addNewOptionOtherPartner() {
    var num = $('.OptionOtherPartner').length, // how many "duplicatable" input fields we currently have
        newNum = new Number(num + 1),      // the numeric ID of the new input field being added
        newElem = $('#OptionOtherPartner' + num).clone().attr('id', 'OptionOtherPartner' + newNum).fadeIn('slow'); // create the new element via clone(), and manipulate it's ID using newNum value
    // manipulate the name/id values of the input inside the new element
    newElem.find('.OtherPartnerTitle').html('OPTION ' + newNum);

    newElem.find('.insert-company-otherpartner').attr('id', 'insert-company-otherpartner' + newNum).attr('name', 'insert-company-otherpartner' + newNum);
    newElem.find('.insert-file-otherpartner').attr('id', 'insert-file-otherpartner' + newNum).val('');
    newElem.find('.insert-code-otherpartner').attr('id', 'insert-code-otherpartner' + newNum).attr('name', 'insert-code-otherpartner' + newNum).val('');
    newElem.find('.insert-price-otherpartner').attr('id', 'insert-price-otherpartner' + newNum).attr('name', 'insert-price-otherpartner' + newNum).val('');
    newElem.find('.insert-currency-otherpartner').attr('id', 'insert-currency-otherpartner' + newNum).attr('name', 'insert-currency-otherpartner' + newNum);
    newElem.find('.insert-contact-otherpartner').attr('id', 'insert-contact-otherpartner' + newNum).attr('name', 'insert-contact-otherpartner' + newNum).val('');
    newElem.find('.insert-phone-otherpartner').attr('id', 'insert-phone-otherpartner' + newNum).attr('name', 'insert-phone-otherpartner' + newNum).val('');
    newElem.find('.insert-note-otherpartner').attr('id', 'insert-note-otherpartner' + newNum).attr('name', 'insert-note-otherpartner' + newNum).val('');
    newElem.find('.OptionOtherPartnerA').attr('data-target', '#demo-otherpartner' + newNum);
    newElem.find('.OptionOtherPartnerBody').attr('id', 'demo-otherpartner' + newNum);

    newElem.find('.countDeadlineOtherPartner').attr('id', 'countDeadlineOtherPartner' + newNum).attr('name', 'NumberDeadlineOtherPartner' + newNum).val(1);

    //deadline
    newElem.find('.DeadlineOtherPartner').attr('id', 'DeadlineOtherPartner' + newNum + 1);
    newElem.find('.btnNewDealineOtherPartner').attr('onclick', 'addNewDeadlineOtherPartner(' + newNum + ')');
    newElem.find('.btnRemoveDealineOtherPartner').attr('onclick', 'removeDeadlineOtherPartner(' + newNum + ',1)').attr('disabled', true);
    newElem.find('.DeadlineOtherPartnerTitle').html('Deadline 1');

    newElem.find('.deadline-otherpartner-a').attr('data-target', '#deadline-otherpartner' + newNum + 1);
    newElem.find('.deadline-otherpartner-body').attr('id', 'deadline-otherpartner' + newNum + 1);

    newElem.find('.deadline-name-otherpartner').attr('id', 'deadline-name-otherpartner' + newNum + 1).attr('name', 'deadline-name-otherpartner' + newNum + 1);
    newElem.find('.deadline-total-otherpartner').attr('id', 'deadline-total-otherpartner' + newNum + 1).attr('name', 'deadline-total-otherpartner' + newNum + 1);
    newElem.find('.deadline-thoigian-otherpartner').attr('id', 'deadline-thoigian-otherpartner' + newNum + 1).attr('name', 'deadline-thoigian-otherpartner' + newNum + 1);
    newElem.find('.deadline-status-otherpartner').attr('id', 'deadline-status-otherpartner' + newNum + 1).attr('name', 'deadline-status-otherpartner' + newNum + 1);
    newElem.find('.deadline-note-otherpartner').attr('id', 'deadline-note-otherpartner' + newNum + 1).attr('name', 'deadline-note-otherpartner' + newNum + 1);
    newElem.find('.deadline-currency-otherpartner').attr('id', 'deadline-currency-otherpartner' + newNum + 1).attr('name', 'deadline-currency-otherpartner' + newNum + 1)

    var arr = newElem.find('.DeadlineOtherPartner').toArray();
    newElem.find('.DeadlineOtherPartner').each(function (index) {
        if (arr.length - 1 != index)
            this.remove();
    });

    $('#OptionOtherPartner' + num).after(newElem);
    $('#countOptionOtherPartner').val(newNum);
    newElem.find('.btnRemoveOptionOtherPartner').attr('disabled', false);
    $('#OptionOtherPartner' + num).find('.btnRemoveOptionOtherPartner').remove();

    /*** upload file ***/
    $('#insert-file-otherpartner' + newNum).change(function () {
        var data = new FormData();
        data.append('FileNameEvent', $('#insert-file-event' + newNum)[0].files[0]);
        data.append('id', newNum);

        var ajaxRequest = $.ajax({
            type: "POST",
            url: 'TourService/UploadFileEvent',
            contentType: false,
            processData: false,
            data: data
        });

        ajaxRequest.done(function (xhr, textStatus) {
            // Onsuccess
        });
    });
    $('#insert-company-otherpartner' + newNum).change(function () {
        $.getJSON('/TourService/LoadPartner/' + $('#insert-company-event' + newNum).val(), function (data) {
            $('#insert-code-event' + newNum).val(data.Code);
            $('#insert-contact-event' + newNum).val(data.StaffContact);
            $('#insert-phone-event' + newNum).val(data.Phone);

        });
    });

    newElem.find("#select2-insert-company-otherpartner" + num + "-container").parent().parent().parent().remove();
    newElem.find("#select2-insert-currency-otherpartner" + num + "-container").parent().parent().parent().remove();
    newElem.find("#select2-deadline-status-otherpartner" + num + arr.length + "-container").parent().parent().parent().remove();
    newElem.find("#select2-deadline-currency-otherpartner" + num + arr.length + "-container").parent().parent().parent().remove();
    newElem.find("#cke_insert-note-otherpartner" + num).remove();
    newElem.find("#cke_deadline-note-otherpartner" + num + arr.length).remove();

    $("#insert-company-otherpartner" + newNum).select2();
    $("#insert-currency-otherpartner" + newNum).select2();
    CKEDITOR.replace("insert-note-otherpartner" + newNum);
    $('#deadline-status-otherpartner' + newNum + 1).select2();
    $('#deadline-currency-otherpartner' + newNum + 1).select2();
    CKEDITOR.replace("deadline-note-otherpartner" + newNum + 1);
}
function addNewDeadlineOtherPartner(i) {
    var num = $('#OptionOtherPartner' + i + ' .DeadlineOtherPartner').length, // how many "duplicatable" input fields we currently have
        newNum = new Number(num + 1),      // the numeric ID of the new input field being added
        newElem = $('#DeadlineOtherPartner' + i + num).clone().attr('id', 'DeadlineOtherPartner' + i + newNum).fadeIn('slow'); // create the new element via clone(), and manipulate it's ID using newNum value
    // manipulate the name/id values of the input inside the new element

    newElem.find('.DeadlineOtherPartnerTitle').html('Deadline ' + newNum);

    $('#DeadlineOtherPartner' + i + num).find('.actions').remove();

    newElem.find('.deadline-name-otherpartner').attr('name', 'deadline-name-otherpartner' + i + newNum).attr('id', 'deadline-name-otherpartner' + i + newNum).val('');
    newElem.find('.deadline-total-otherpartner').attr('name', 'deadline-total-otherpartner' + i + newNum).attr('id', 'deadline-total-otherpartner' + i + newNum).val('');
    newElem.find('.deadline-thoigian-otherpartner').attr('id', 'deadline-thoigian-otherpartner' + i + newNum).attr('name', 'deadline-thoigian-otherpartner' + i + newNum).val('');
    newElem.find('.deadline-status-otherpartner').attr('id', 'deadline-status-otherpartner' + i + newNum).attr('name', 'deadline-status-otherpartner' + i + newNum);
    newElem.find('.deadline-currency-otherpartner').attr('id', 'deadline-currency-otherpartner' + i + newNum).attr('name', 'deadline-currency-otherpartner' + i + newNum);
    newElem.find('.deadline-note-otherpartner').attr('id', 'deadline-note-otherpartner' + i + newNum).attr('name', 'deadline-note-otherpartner' + i + newNum);

    newElem.find('.deadline-otherpartner-a').attr('data-target', '#deadline-otherpartner' + i + newNum);
    newElem.find('.deadline-otherpartner-body').attr('id', 'deadline-otherpartner' + i + newNum);

    newElem.find('.btnRemoveDealineOtherPartner').attr('onclick', 'removeDeadlineOtherPartner(' + i + "," + newNum + ')');
    newElem.find('.btnRemoveDealineOtherPartner').attr('disabled', false);

    $('#DeadlineOtherPartner' + i + num).after(newElem);
    $("#countDeadlineOtherPartner" + i).val(newNum);

    newElem.find("#select2-deadline-status-otherpartner" + i + num + "-container").parent().parent().parent().remove();
    newElem.find("#select2-deadline-currency-otherpartner" + i + num + "-container").parent().parent().parent().remove();
    newElem.find("#cke_deadline-note-otherpartner" + i + num).remove();

    $('#deadline-status-otherpartner' + i + newNum).select2();
    $('#deadline-currency-otherpartner' + i + newNum).select2();
    CKEDITOR.replace("deadline-note-otherpartner" + i + newNum);
}
function removeOptionOtherPartner() {
    var num = $('.OptionOtherPartner').length,
        option = $('#OptionOtherPartner' + (num - 1)),
        optionremove = $('#OptionOtherPartner' + num),
        actions = $('#OptionOtherPartner' + num).find('.actionsOptionOtherPartner');
    if (num == 2)
        actions.find('.btnRemoveOptionOtherPartner').attr('disabled', true);
    option.find('.actionsOptionOtherPartner').after(actions);
    optionremove.remove();
    $('#countOptionOtherPartner').val(num - 1);
}
function removeDeadlineOtherPartner(x, y) {

    var actions = $('#DeadlineOtherPartner' + x + y).find('.actions').clone();
    actions.find('.btnRemoveDealineOtherPartner').attr('onclick', 'removeDeadlineOtherPartner(' + x + "," + (y - 1) + ')');
    if (y == 2)
        actions.find('.btnRemoveDealineOtherPartner').attr('disabled', true);
    $('#DeadlineOtherPartner' + x + (y - 1)).find('.caption').after(actions);
    $('#DeadlineOtherPartner' + x + y).remove();
    $("#countDeadlineOtherPartner" + x).val(y - 1);
}
//end OtherPartner

///Landtour
$("#insert-currency-landtour1").select2();
$("#insert-company-landtour1").select2();
$("#deadline-status-landtour11").select2();
$("#deadline-currency-landtour11").select2();
CKEDITOR.replace("insert-note-landtour1");
CKEDITOR.replace("deadline-note-landtour11");
/******** duplicate *******/
function addNewOptionLandtour() {
    var num = $('.OptionLandtour').length, // how many "duplicatable" input fields we currently have
        newNum = new Number(num + 1),      // the numeric ID of the new input field being added
        newElem = $('#OptionLandtour' + num).clone().attr('id', 'OptionLandtour' + newNum).fadeIn('slow'); // create the new element via clone(), and manipulate it's ID using newNum value
    // manipulate the name/id values of the input inside the new element
    newElem.find('.landtourTitle').html('OPTION ' + newNum);

    newElem.find('.insert-company-landtour').attr('id', 'insert-company-landtour' + newNum).attr('name', 'insert-company-landtour' + newNum);
    newElem.find('.insert-file-landtour').attr('id', 'insert-file-landtour' + newNum).val('');
    newElem.find('.insert-code-landtour').attr('id', 'insert-code-landtour' + newNum).attr('name', 'insert-code-landtour' + newNum).val('');
    newElem.find('.insert-price-landtour').attr('id', 'insert-price-landtour' + newNum).attr('name', 'insert-price-landtour' + newNum).val('');
    newElem.find('.insert-currency-landtour').attr('id', 'insert-currency-landtour' + newNum).attr('name', 'insert-currency-landtour' + newNum);
    newElem.find('.insert-contact-landtour').attr('id', 'insert-contact-landtour' + newNum).attr('name', 'insert-contact-landtour' + newNum).val('');
    newElem.find('.insert-phone-landtour').attr('id', 'insert-phone-landtour' + newNum).attr('name', 'insert-phone-landtour' + newNum).val('');
    newElem.find('.insert-note-landtour').attr('id', 'insert-note-landtour' + newNum).attr('name', 'insert-note-landtour' + newNum).val('');
    newElem.find('.OptionLandtourA').attr('data-target', '#demo-landtour' + newNum);
    newElem.find('.OptionLandtourBody').attr('id', 'demo-landtour' + newNum);

    newElem.find('.countDeadlineLandtour').attr('id', 'countDeadlineLandtour' + newNum).attr('name', 'NumberDeadlineLandtour' + newNum).val(1);

    //deadline
    newElem.find('.DeadlineLandtour').attr('id', 'DeadlineLandtour' + newNum + 1);
    newElem.find('.btnNewDealineLandtour').attr('onclick', 'addNewDeadlineLandtour(' + newNum + ')');
    newElem.find('.btnRemoveDealineLandtour').attr('onclick', 'removeDeadlineLandtour(' + newNum + ',1)').attr('disabled', true);
    newElem.find('.DeadlineLandtourTitle').html('Deadline 1');

    newElem.find('.deadline-landtour-a').attr('data-target', '#deadline-landtour' + newNum + 1);
    newElem.find('.deadline-landtour-body').attr('id', 'deadline-landtour' + newNum + 1);

    newElem.find('.deadline-name-landtour').attr('id', 'deadline-name-landtour' + newNum + 1).attr('name', 'deadline-name-landtour' + newNum + 1);
    newElem.find('.deadline-total-landtour').attr('id', 'deadline-total-landtour' + newNum + 1).attr('name', 'deadline-total-landtour' + newNum + 1);
    newElem.find('.deadline-thoigian-landtour').attr('id', 'deadline-thoigian-landtour' + newNum + 1).attr('name', 'deadline-thoigian-landtour' + newNum + 1);
    newElem.find('.deadline-status-landtour').attr('id', 'deadline-status-landtour' + newNum + 1).attr('name', 'deadline-status-landtour' + newNum + 1);
    newElem.find('.deadline-note-landtour').attr('id', 'deadline-note-landtour' + newNum + 1).attr('name', 'deadline-note-landtour' + newNum + 1);
    newElem.find('.deadline-currency-landtour').attr('id', 'deadline-currency-landtour' + newNum + 1).attr('name', 'deadline-currency-landtour' + newNum + 1)

    var arr = newElem.find('.DeadlineLandtour').toArray();
    newElem.find('.DeadlineLandtour').each(function (index) {
        if (arr.length - 1 != index)
            this.remove();
    });

    $('#OptionLandtour' + num).after(newElem);
    $('#countOptionLandtour').val(newNum);
    newElem.find('.btnRemoveOptionLandtour').attr('disabled', false);
    $('#OptionLandtour' + num).find('.btnRemoveOptionLandtour').remove();

    /*** upload file ***/
    $('#insert-file-landtour' + newNum).change(function () {
        var data = new FormData();
        data.append('FileNameEvent', $('#insert-file-event' + newNum)[0].files[0]);
        data.append('id', newNum);

        var ajaxRequest = $.ajax({
            type: "POST",
            url: 'TourService/UploadFileEvent',
            contentType: false,
            processData: false,
            data: data
        });

        ajaxRequest.done(function (xhr, textStatus) {
            // Onsuccess
        });
    });
    $('#insert-company-landtour' + newNum).change(function () {
        $.getJSON('/TourService/LoadPartner/' + $('#insert-company-event' + newNum).val(), function (data) {
            $('#insert-code-event' + newNum).val(data.Code);
            $('#insert-contact-event' + newNum).val(data.StaffContact);
            $('#insert-phone-event' + newNum).val(data.Phone);

        });
    });

    newElem.find("#select2-insert-company-landtour" + num + "-container").parent().parent().parent().remove();
    newElem.find("#select2-insert-currency-landtour" + num + "-container").parent().parent().parent().remove();
    newElem.find("#select2-deadline-status-landtour" + num + arr.length + "-container").parent().parent().parent().remove();
    newElem.find("#select2-deadline-currency-landtour" + num + arr.length + "-container").parent().parent().parent().remove();
    newElem.find("#cke_insert-note-landtour" + num).remove();
    newElem.find("#cke_deadline-note-landtour" + num + arr.length).remove();

    $("#insert-company-landtour" + newNum).select2();
    $("#insert-currency-landtour" + newNum).select2();
    CKEDITOR.replace("insert-note-landtour" + newNum);
    $('#deadline-status-landtour' + newNum + 1).select2();
    $('#deadline-currency-landtour' + newNum + 1).select2();
    CKEDITOR.replace("deadline-note-landtour" + newNum + 1);
}
function addNewDeadlineLandtour(i) {
    var num = $('#OptionLandtour' + i + ' .DeadlineLandtour').length, // how many "duplicatable" input fields we currently have
        newNum = new Number(num + 1),      // the numeric ID of the new input field being added
        newElem = $('#DeadlineLandtour' + i + num).clone().attr('id', 'DeadlineLandtour' + i + newNum).fadeIn('slow'); // create the new element via clone(), and manipulate it's ID using newNum value
    // manipulate the name/id values of the input inside the new element

    newElem.find('.DeadlineLandtourTitle').html('Deadline ' + newNum);

    $('#DeadlineLandtour' + i + num).find('.actions').remove();

    newElem.find('.deadline-name-landtour').attr('name', 'deadline-name-landtour' + i + newNum).attr('id', 'deadline-name-landtour' + i + newNum).val('');
    newElem.find('.deadline-total-landtour').attr('name', 'deadline-total-landtour' + i + newNum).attr('id', 'deadline-total-landtour' + i + newNum).val('');
    newElem.find('.deadline-thoigian-landtour').attr('id', 'deadline-thoigian-landtour' + i + newNum).attr('name', 'deadline-thoigian-landtour' + i + newNum).val('');
    newElem.find('.deadline-status-landtour').attr('id', 'deadline-status-landtour' + i + newNum).attr('name', 'deadline-status-landtour' + i + newNum);
    newElem.find('.deadline-currency-landtour').attr('id', 'deadline-currency-landtour' + i + newNum).attr('name', 'deadline-currency-landtour' + i + newNum);
    newElem.find('.deadline-note-landtour').attr('id', 'deadline-note-landtour' + i + newNum).attr('name', 'deadline-note-landtour' + i + newNum);

    newElem.find('.deadline-landtour-a').attr('data-target', '#deadline-landtour' + i + newNum);
    newElem.find('.deadline-landtour-body').attr('id', 'deadline-landtour' + i + newNum);

    newElem.find('.btnRemoveDealineLandtour').attr('onclick', 'removeDeadlineLandtour(' + i + "," + newNum + ')');
    newElem.find('.btnRemoveDealineLandtour').attr('disabled', false);

    $('#DeadlineLandtour' + i + num).after(newElem);
    $("#countDeadlineLandtour" + i).val(newNum);

    newElem.find("#select2-deadline-status-landtour" + i + num + "-container").parent().parent().parent().remove();
    newElem.find("#select2-deadline-currency-landtour" + i + num + "-container").parent().parent().parent().remove();
    newElem.find("#cke_deadline-note-landtour" + i + num).remove();

    $('#deadline-status-landtour' + i + newNum).select2();
    $('#deadline-currency-landtour' + i + newNum).select2();
    CKEDITOR.replace("deadline-note-landtour" + i + newNum);
}
function removeOptionLandtour() {
    var num = $('.OptionLandtour').length,
        option = $('#OptionLandtour' + (num - 1)),
        optionremove = $('#OptionLandtour' + num),
        actions = $('#OptionLandtour' + num).find('.actionsOptionLandtour');
    if (num == 2)
        actions.find('.btnRemoveOptionLandtour').attr('disabled', true);
    option.find('.actionsOptionLandtour').after(actions);
    optionremove.remove();
    $('#countOptionLandtour').val(num - 1);
}
function removeDeadlineLandtour(x, y) {

    var actions = $('#DeadlineLandtour' + x + y).find('.actions').clone();
    actions.find('.btnRemoveDealineLandtour').attr('onclick', 'removeDeadlineLandtour(' + x + "," + (y - 1) + ')');
    if (y == 2)
        actions.find('.btnRemoveDealineLandtour').attr('disabled', true);
    $('#DeadlineLandtour' + x + (y - 1)).find('.caption').after(actions);
    $('#DeadlineLandtour' + x + y).remove();
    $("#countDeadlineLandtour" + x).val(y - 1);
}
//end landtour

//==============================================================================//

///Event
$("#insert-currency-event1").select2();
$("#insert-company-event1").select2();
$("#deadline-status-event11").select2();
$("#deadline-currency-event11").select2();
CKEDITOR.replace("insert-note-event1");
CKEDITOR.replace("deadline-note-event11");
/******** duplicate *******/
function addNewOptionEvent() {
    var num = $('.OptionEvent').length, // how many "duplicatable" input fields we currently have
        newNum = new Number(num + 1),      // the numeric ID of the new input field being added
        newElem = $('#OptionEvent' + num).clone().attr('id', 'OptionEvent' + newNum).fadeIn('slow'); // create the new element via clone(), and manipulate it's ID using newNum value
    // manipulate the name/id values of the input inside the new element
    newElem.find('.eventTitle').html('OPTION ' + newNum);

    newElem.find('.insert-company-event').attr('id', 'insert-company-event' + newNum).attr('name', 'insert-company-event' + newNum);
    newElem.find('.insert-file-event').attr('id', 'insert-file-event' + newNum).val('');
    newElem.find('.insert-code-event').attr('id', 'insert-code-event' + newNum).attr('name', 'insert-code-event' + newNum).val('');
    newElem.find('.insert-price-event').attr('id', 'insert-price-event' + newNum).attr('name', 'insert-price-event' + newNum).val('');
    newElem.find('.insert-currency-event').attr('id', 'insert-currency-event' + newNum).attr('name', 'insert-currency-event' + newNum);
    newElem.find('.insert-contact-event').attr('id', 'insert-contact-event' + newNum).attr('name', 'insert-contact-event' + newNum).val('');
    newElem.find('.insert-phone-event').attr('id', 'insert-phone-event' + newNum).attr('name', 'insert-phone-event' + newNum).val('');
    newElem.find('.insert-note-event').attr('id', 'insert-note-event' + newNum).attr('name', 'insert-note-event' + newNum).val('');
    newElem.find('.OptionEventA').attr('data-target', '#demo-event' + newNum);
    newElem.find('.OptionEventBody').attr('id', 'demo-event' + newNum);

    newElem.find('.countDeadline').attr('id', 'countDeadlineEvent' + newNum).attr('name', 'NumberDeadlineEvent' + newNum).val(1);

    //deadline
    newElem.find('.DeadlineEvent').attr('id', 'DeadlineEvent' + newNum + 1);
    newElem.find('.btnNewDealineEvent').attr('onclick', 'addNewDeadlineEvent(' + newNum + ')');
    newElem.find('.btnRemoveDealineEvent').attr('onclick', 'removeDeadlineEvent(' + newNum + ',1)').attr('disabled', true);
    newElem.find('.DeadlineEventTitle').html('Deadline 1');

    newElem.find('.deadline-event-a').attr('data-target', '#deadline-event' + newNum + 1);
    newElem.find('.deadline-event-body').attr('id', 'deadline-event' + newNum + 1);

    newElem.find('.deadline-name-event').attr('id', 'deadline-name-event' + newNum + 1).attr('name', 'deadline-name-event' + newNum + 1);
    newElem.find('.deadline-total-event').attr('id', 'deadline-total-event' + newNum + 1).attr('name', 'deadline-total-event' + newNum + 1);
    newElem.find('.deadline-thoigian-event').attr('id', 'deadline-thoigian-event' + newNum + 1).attr('name', 'deadline-thoigian-event' + newNum + 1);
    newElem.find('.deadline-status-event').attr('id', 'deadline-status-event' + newNum + 1).attr('name', 'deadline-status-event' + newNum + 1);
    newElem.find('.deadline-note-event').attr('id', 'deadline-note-event' + newNum + 1).attr('name', 'deadline-note-event' + newNum + 1);
    newElem.find('.deadline-currency-event').attr('id', 'deadline-currency-event' + newNum + 1).attr('name', 'deadline-currency-event' + newNum + 1)

    var arr = newElem.find('.DeadlineEvent').toArray();
    newElem.find('.DeadlineEvent').each(function (index) {
        if (arr.length - 1 != index)
            this.remove();
    });

    $('#OptionEvent' + num).after(newElem);
    $('#countOptionEvent').val(newNum);
    newElem.find('.btnRemoveOptionEvent').attr('disabled', false);
    $('#OptionEvent' + num).find('.btnRemoveOptionEvent').remove();

    /*** upload file ***/
    $('#insert-file-event' + newNum).change(function () {
        var data = new FormData();
        data.append('FileNameEvent', $('#insert-file-event' + newNum)[0].files[0]);
        data.append('id', newNum);

        var ajaxRequest = $.ajax({
            type: "POST",
            url: 'TourService/UploadFileEvent',
            contentType: false,
            processData: false,
            data: data
        });

        ajaxRequest.done(function (xhr, textStatus) {
            // Onsuccess
        });
    });
    $('#insert-company-event' + newNum).change(function () {
        $.getJSON('/TourService/LoadPartner/' + $('#insert-company-event' + newNum).val(), function (data) {
            $('#insert-code-event' + newNum).val(data.Code);
            $('#insert-contact-event' + newNum).val(data.StaffContact);
            $('#insert-phone-event' + newNum).val(data.Phone);

        });
    });

    newElem.find("#select2-insert-company-event" + num + "-container").parent().parent().parent().remove();
    newElem.find("#select2-insert-currency-event" + num + "-container").parent().parent().parent().remove();
    newElem.find("#select2-deadline-status-event" + num + arr.length + "-container").parent().parent().parent().remove();
    newElem.find("#select2-deadline-currency-event" + num + arr.length + "-container").parent().parent().parent().remove();
    newElem.find("#cke_insert-note-event" + num).remove();
    newElem.find("#cke_deadline-note-event" + num + arr.length).remove();

    $("#insert-company-event" + newNum).select2();
    $("#insert-currency-event" + newNum).select2();
    CKEDITOR.replace("insert-note-event" + newNum);
    $('#deadline-status-event' + newNum + 1).select2();
    $('#deadline-currency-event' + newNum + 1).select2();
    CKEDITOR.replace("deadline-note-event" + newNum + 1);
}
function addNewDeadlineEvent(i) {
    var num = $('#OptionEvent' + i + ' .DeadlineEvent').length, // how many "duplicatable" input fields we currently have
        newNum = new Number(num + 1),      // the numeric ID of the new input field being added
        newElem = $('#DeadlineEvent' + i + num).clone().attr('id', 'DeadlineEvent' + i + newNum).fadeIn('slow'); // create the new element via clone(), and manipulate it's ID using newNum value
    // manipulate the name/id values of the input inside the new element

    newElem.find('.DeadlineEventTitle').html('Deadline ' + newNum);

    $('#DeadlineEvent' + i + num).find('.actions').remove();

    newElem.find('.deadline-name-event').attr('name', 'deadline-name-event' + i + newNum).attr('id', 'deadline-name-event' + i + newNum).val('');
    newElem.find('.deadline-total-event').attr('name', 'deadline-total-event' + i + newNum).attr('id', 'deadline-total-event' + i + newNum).val('');
    newElem.find('.deadline-thoigian-event').attr('id', 'deadline-thoigian-event' + i + newNum).attr('name', 'deadline-thoigian-event' + i + newNum).val('');
    newElem.find('.deadline-status-event').attr('id', 'deadline-status-event' + i + newNum).attr('name', 'deadline-status-event' + i + newNum);
    newElem.find('.deadline-currency-event').attr('id', 'deadline-currency-event' + i + newNum).attr('name', 'deadline-currency-event' + i + newNum);
    newElem.find('.deadline-note-event').attr('id', 'deadline-note-event' + i + newNum).attr('name', 'deadline-note-event' + i + newNum);

    newElem.find('.deadline-event-a').attr('data-target', '#deadline-event' + i + newNum);
    newElem.find('.deadline-event-body').attr('id', 'deadline-event' + i + newNum);

    newElem.find('.btnRemoveDealineEvent').attr('onclick', 'removeDeadlineEvent(' + i + "," + newNum + ')');
    newElem.find('.btnRemoveDealineEvent').attr('disabled', false);

    $('#DeadlineEvent' + i + num).after(newElem);
    $("#countDeadlineEvent" + i).val(newNum);

    newElem.find("#select2-deadline-status-event" + i + num + "-container").parent().parent().parent().remove();
    newElem.find("#select2-deadline-currency-event" + i + num + "-container").parent().parent().parent().remove();
    newElem.find("#cke_deadline-note-event" + i + num).remove();

    $('#deadline-status-event' + i + newNum).select2();
    $('#deadline-currency-event' + i + newNum).select2();
    CKEDITOR.replace("deadline-note-event" + i + newNum);
}
function removeOptionEvent() {
    var num = $('.OptionEvent').length,
        option = $('#OptionEvent' + (num - 1)),
        optionremove = $('#OptionEvent' + num),
        actions = $('#OptionEvent' + num).find('.actionsOptionEvent');
    if (num == 2)
        actions.find('.btnRemoveOptionEvent').attr('disabled', true);
    option.find('.actionsOptionEvent').after(actions);
    optionremove.remove();
    $('#countOptionEvent').val(num - 1);
}
function removeDeadlineEvent(x, y) {

    var actions = $('#DeadlineEvent' + x + y).find('.actions').clone();
    actions.find('.btnRemoveDealineEvent').attr('onclick', 'removeDeadlineEvent(' + x + "," + (y - 1) + ')');
    if (y == 2)
        actions.find('.btnRemoveDealineEvent').attr('disabled', true);
    $('#DeadlineEvent' + x + (y - 1)).find('.caption').after(actions);
    $('#DeadlineEvent' + x + y).remove();
    $("#countDeadlineEvent" + x).val(y - 1);
}
//end event

//==============================================================================//

///Nhà hàng
$("#RestaurantName1").select2();
$('#DeadlineStatus11').select2();
$('#RestaurantCurrency1').select2();
$("#deadline-currency-restaurant11").select2();
CKEDITOR.replace("RestaurantNote1");
CKEDITOR.replace("DeadlineNote11");
/******** duplicate *******/
function addNewOption() {
    var num = $('.OptionRestaurant').length, // how many "duplicatable" input fields we currently have
        newNum = new Number(num + 1),      // the numeric ID of the new input field being added
        newElem = $('#OptionRestaurant' + num).clone().attr('id', 'OptionRestaurant' + newNum).fadeIn('slow'); // create the new element via clone(), and manipulate it's ID using newNum value
    // manipulate the name/id values of the input inside the new element

    newElem.find('.RestaurantName').attr('id', 'RestaurantName' + newNum).attr('name', 'RestaurantName' + newNum);
    newElem.find('.RestaurantPrice').attr('id', 'RestaurantPrice' + newNum).attr('name', 'RestaurantPrice' + newNum).val('');
    newElem.find('.RestaurantAddress').attr('id', 'RestaurantAddress' + newNum).attr('name', 'RestaurantAddress' + newNum).val('');
    newElem.find('.RestaurantCode').attr('id', 'RestaurantCode' + newNum).attr('name', 'RestaurantCode' + newNum).val('');
    newElem.find('.RestaurantNote').attr('id', 'RestaurantNote' + newNum).attr('name', 'RestaurantNote' + newNum);
    newElem.find('.RestaurantDocument').attr('id', 'RestaurantDocument' + newNum);
    newElem.find('.NguoiLienHe').attr('id', 'NguoiLienHe' + newNum).attr('name', 'NguoiLienHe' + newNum).val('');
    newElem.find('.DienThoai').attr('id', 'DienThoai' + newNum).attr('name', 'DienThoai' + newNum).val('');
    newElem.find('.RestaurantCurrency').attr('id', 'RestaurantCurrency' + newNum).attr('name', 'RestaurantCurrency' + newNum);
    newElem.find('.OptionRestaurantA').attr('data-target', '#restaurant' + newNum);
    newElem.find('.OptionRestaurantBody').attr('id', 'restaurant' + newNum);

    newElem.find('.OptionTitle').html('OPTION ' + newNum);

    //deadline
    newElem.find('.btnNewDealine').attr('onclick', 'addNewDeadline(' + newNum + ')');
    newElem.find('.btnRemoveDealine').attr('onclick', 'removeDeadline(' + newNum + ',1)').attr('disabled', true);

    newElem.find('.DeadlineRestauran').attr('id', 'DeadlineRestauran' + newNum + 1);
    newElem.find('.DeadlineStatus').attr('id', 'DeadlineStatus' + newNum + 1).attr('name', 'DeadlineStatus' + newNum + 1);
    newElem.find('.DeadlineNote').attr('id', 'DeadlineNote' + newNum + 1).attr('name', 'DeadlineNote' + newNum + 1)
    newElem.find('.DeadlineTen').attr('id', 'DeadlineTen' + newNum + 1).attr('name', 'DeadlineTen' + newNum + 1).val('')
    newElem.find('.DeadlineDeposit').attr('id', 'DeadlineDeposit' + newNum + 1).attr('name', 'DeadlineDeposit' + newNum + 1).val('')
    newElem.find('.DeadlineThoiGian').attr('id', 'DeadlineThoiGian' + newNum + 1).attr('name', 'DeadlineThoiGian' + newNum + 1).val('')
    newElem.find('.DeadlineRestauranA').attr('data-target', '#deadline-restauran' + newNum + 1);
    newElem.find('.DeadlineRestauranBody').attr('id', 'deadline-restauran' + newNum + 1);
    newElem.find('.DeadlineTitle').html('Deadline 1');
    newElem.find('.deadline-currency-restaurant').attr('id', 'deadline-currency-restaurant' + newNum + 1).attr('name', 'deadline-currency-restaurant' + newNum + 1);

    newElem.find('.countDeadline').attr('id', 'countDeadlineRestaurant' + newNum).attr('name', 'NumberDeadlineRestaurant' + newNum).val(1)

    var arr = newElem.find('.DeadlineRestauran').toArray();
    newElem.find('.DeadlineRestauran').each(function (index) {
        if (arr.length - 1 != index)
            this.remove();
    });
    $('#OptionRestaurant' + num).after(newElem);
    $('#countOptionRestaurant').val(newNum);

    $('#RestaurantDocument' + newNum).change(function () {
        var data = new FormData();
        data.append('RestaurantDocument', $('#RestaurantDocument' + newNum)[0].files[0]);
        data.append('id', newNum);

        var ajaxRequest = $.ajax({
            type: "POST",
            url: 'TourService/UploadFileRestaurant',
            contentType: false,
            processData: false,
            data: data
        });

        ajaxRequest.done(function (xhr, textStatus) {
            // Onsuccess
        });
    });
    $('#RestaurantName' + newNum).change(function () {
        $.getJSON('/TourService/LoadPartner/' + $('#RestaurantName' + newNum).val(), function (data) {
            $('#RestaurantAddress' + newNum).val(data.Address);
            $('#RestaurantCode' + newNum).val(data.Code);
            $('#NguoiLienHe' + newNum).val(data.StaffContact);
            $('#DienThoai' + newNum).val(data.Phone);
        });
    });

    CKEDITOR.replace("RestaurantNote" + newNum);
    // for (var i = 1; i < newNum; i++) {
    newElem.find("#select2-RestaurantName" + num + "-container").parent().parent().parent().remove();
    newElem.find("#select2-RestaurantCurrency" + num + "-container").parent().parent().parent().remove();
    newElem.find("#cke_RestaurantNote" + num).remove();
    newElem.find("#cke_DeadlineNote" + num + arr.length).remove();
    newElem.find("#select2-DeadlineStatus" + num + arr.length + "-container").parent().parent().parent().remove();
    newElem.find("#select2-deadline-currency-restaurant" + num + arr.length + "-container").parent().parent().parent().remove();
    //}
    $("#RestaurantCurrency" + newNum).select2();
    $("#RestaurantName" + newNum).select2();
    $("#DeadlineStatus" + newNum + 1).select2();
    $("#deadline-currency-restaurant" + newNum + 1).select2();
    CKEDITOR.replace("DeadlineNote" + newNum + 1);
    newElem.find('.btnRemoveOption').attr('disabled', false);
    $('#OptionRestaurant' + num).find('.actionsOption').remove();
}
function addNewDeadline(i) {
    var num = $('#OptionRestaurant' + i + ' .DeadlineRestauran').length, // how many "duplicatable" input fields we currently have
        newNum = new Number(num + 1),      // the numeric ID of the new input field being added
        newElem = $('#DeadlineRestauran' + i + num).clone().attr('id', 'DeadlineRestauran' + i + newNum).fadeIn('slow'); // create the new element via clone(), and manipulate it's ID using newNum value
    // manipulate the name/id values of the input inside the new element

    $('#DeadlineRestauran' + i + num).find('.actions').remove();

    newElem.find('.deadline-currency-restaurant').attr('name', 'deadline-currency-restaurant' + i + newNum).attr('id', 'deadline-currency-restaurant' + i + newNum);
    newElem.find('.DeadlineStatus').attr('name', 'DeadlineStatus' + i + newNum).attr('id', 'DeadlineStatus' + i + newNum);
    newElem.find('.DeadlineNote').attr('name', 'DeadlineNote' + i + newNum).attr('id', 'DeadlineNote' + i + newNum);
    newElem.find('.DeadlineTen').attr('id', 'DeadlineTen' + i + newNum).attr('name', 'DeadlineTen' + i + newNum).val('')
    newElem.find('.DeadlineDeposit').attr('id', 'DeadlineDeposit' + i + newNum).attr('name', 'DeadlineDeposit' + i + newNum).val('')
    newElem.find('.DeadlineThoiGian').attr('id', 'DeadlineThoiGian' + i + newNum).attr('name', 'DeadlineThoiGian' + i + newNum).val('')

    newElem.find('.DeadlineRestauranA').attr('data-target', '#deadline-restauran' + i + newNum);
    newElem.find('.DeadlineRestauranBody').attr('id', 'deadline-restauran' + i + newNum);

    newElem.find('.DeadlineTitle').html('Deadline ' + newNum);

    newElem.find('.btnRemoveDealine').attr('onclick', 'removeDeadline(' + i + "," + newNum + ')');
    newElem.find('.btnRemoveDealine').attr('disabled', false);

    $('#DeadlineRestauran' + i + num).after(newElem);
    $("#countDeadlineRestaurant" + i).val(newNum);

    CKEDITOR.replace("DeadlineNote" + i + newNum);
    newElem.find("#select2-DeadlineStatus" + i + num + "-container").parent().parent().parent().remove();
    newElem.find("#select2-deadline-currency-restaurant" + i + num + "-container").parent().parent().parent().remove();
    newElem.find("#cke_DeadlineNote" + i + num).remove();
    $("#DeadlineStatus" + i + newNum).select2();
    $("#deadline-currency-restaurant" + i + newNum).select2();
}
function removeDeadline(x, y) {
    var actions = $('#DeadlineRestauran' + x + y).find('.actions').clone();
    actions.find('.btnRemoveDealine').attr('onclick', 'removeDeadline(' + x + "," + (y - 1) + ')');
    if (y == 2)
        actions.find('.btnRemoveDealine').attr('disabled', true);
    $('#DeadlineRestauran' + x + (y - 1)).find('.caption').after(actions);
    $('#DeadlineRestauran' + x + y).remove();
    $("#countDeadlineRestaurant" + x).val(y - 1);
}
function removeOption() {
    var num = $('.OptionRestaurant').length,
        option = $('#OptionRestaurant' + (num - 1)),
        optionremove = $('#OptionRestaurant' + num),
        actions = $('#OptionRestaurant' + num).find('.actionsOption');
    if (num == 2)
        actions.find('.btnRemoveOption').attr('disabled', true);
    option.find('.captionOption').after(actions);
    optionremove.remove();
    $('#countOptionRestaurant').val(num - 1);
}
//end nhà hàng

//=============================================================================//

//khách sạn
$("#hotel-tour1").select2();
$("#currency-hotel-tour1").select2();
$('#star-hotel1').select2();
$('#deadline-status-hotel11').select2();
$('#deadline-currency-hotel11').select2();
CKEDITOR.replace("note-hotel1");
CKEDITOR.replace("deadline-note-hotel11");
/******** duplicate *******/
function addNewOptionHotel() {
    var num = $('.OptionHotel').length, // how many "duplicatable" input fields we currently have
        newNum = new Number(num + 1),      // the numeric ID of the new input field being added
        newElem = $('#OptionHotel' + num).clone().attr('id', 'OptionHotel' + newNum).fadeIn('slow'); // create the new element via clone(), and manipulate it's ID using newNum value
    // manipulate the name/id values of the input inside the new element
    newElem.find('.OptionTitle').html('OPTION ' + newNum);

    newElem.find('.hotel-tour').attr('id', 'hotel-tour' + newNum).attr('name', 'hotel-tour' + newNum);
    newElem.find('.currency-hotel-tour').attr('id', 'currency-hotel-tour' + newNum).attr('name', 'currency-hotel-tour' + newNum);
    newElem.find('.star-hotel').attr('id', 'star-hotel' + newNum).attr('name', 'star-hotel' + newNum);
    newElem.find('.tungay-hotel').attr('id', 'tungay-hotel' + newNum).attr('name', 'tungay-hotel' + newNum).val('');
    newElem.find('.room-hotel').attr('id', 'room-hotel' + newNum).attr('name', 'room-hotel' + newNum).val('');
    newElem.find('.nguoi-lien-he-hotel').attr('id', 'nguoi-lien-he-hotel' + newNum).attr('name', 'nguoi-lien-he-hotel' + newNum).val('');
    newElem.find('.code-hotel').attr('id', 'code-hotel' + newNum).attr('name', 'code-hotel' + newNum).val('');
    newElem.find('.position-hotel').attr('id', 'position-hotel' + newNum).attr('name', 'position-hotel' + newNum).val('');
    newElem.find('.night-hotel').attr('id', 'night-hotel' + newNum).attr('name', 'night-hotel' + newNum).val('');
    newElem.find('.price-hotel').attr('id', 'price-hotel' + newNum).attr('name', 'price-hotel' + newNum).val('');
    newElem.find('.phone-hotel').attr('id', 'phone-hotel' + newNum).attr('name', 'phone-hotel' + newNum).val('');
    newElem.find('.note-hotel').attr('id', 'note-hotel' + newNum).attr('name', 'note-hotel' + newNum);
    newElem.find('.OptionHotelA').attr('data-target', '#hotel' + newNum);
    newElem.find('.OptionHotelBody').attr('id', 'hotel' + newNum);

    //deadline
    newElem.find('.DeadlineHotel').attr('id', 'DeadlineHotel' + newNum + 1);
    newElem.find('.btnNewDealine').attr('onclick', 'addNewDeadlineHotel(' + newNum + ')');
    newElem.find('.btnRemoveDealine').attr('onclick', 'removeDeadlineHotel(' + newNum + ',1)').attr('disabled', true);
    newElem.find('.DeadlineTitle').html('Deadline 1');

    newElem.find('.deadline-hotel-a').attr('data-target', '#deadline-hotel' + newNum + 1);
    newElem.find('.deadline-hotel-body').attr('id', 'deadline-hotel' + newNum + 1);

    newElem.find('.deadline-name-hotel').attr('id', 'deadline-name-hotel' + newNum + 1).attr('name', 'deadline-name-hotel' + newNum + 1).val('');
    newElem.find('.deadline-total-hotel').attr('id', 'deadline-total-hotel' + newNum + 1).attr('name', 'deadline-total-hotel' + newNum + 1).val('');
    newElem.find('.deadline-thoigian-hotel').attr('id', 'deadline-thoigian-hotel' + newNum + 1).attr('name', 'deadline-thoigian-hotel' + newNum + 1).val('');
    newElem.find('.deadline-status-hotel').attr('id', 'deadline-status-hotel' + newNum + 1).attr('name', 'deadline-status-hotel' + newNum + 1);
    newElem.find('.deadline-currency-hotel').attr('id', 'deadline-currency-hotel' + newNum + 1).attr('name', 'deadline-currency-hotel' + newNum + 1);
    newElem.find('.deadline-note-hotel').attr('id', 'deadline-note-hotel' + newNum + 1).attr('name', 'deadline-note-hotel' + newNum + 1)

    newElem.find('.countDeadline').attr('id', 'countDeadlineHotel' + newNum).attr('name', 'NumberDeadlineHotel' + newNum).val(1)

    var arr = newElem.find('.DeadlineHotel').toArray();
    newElem.find('.DeadlineHotel').each(function (index) {
        if (arr.length - 1 != index)
            this.remove();
    });
    $('#OptionHotel' + num).after(newElem);
    $('#countOptionHotel').val(newNum);
    newElem.find('.btnRemoveOption').attr('disabled', false);
    $('#OptionHotel' + num).find('.actionsOption').remove();

    newElem.find("#select2-hotel-tour" + num + "-container").parent().parent().parent().remove();
    newElem.find("#select2-currency-hotel-tour" + num + "-container").parent().parent().parent().remove();
    newElem.find("#select2-star-hotel" + num + "-container").parent().parent().parent().remove();
    newElem.find("#select2-deadline-status-hotel" + num + arr.length + "-container").parent().parent().parent().remove();
    newElem.find("#select2-deadline-currency-hotel" + num + arr.length + "-container").parent().parent().parent().remove();
    newElem.find("#cke_note-hotel" + num).remove();
    newElem.find("#cke_deadline-note-hotel" + num + arr.length).remove();

    $('#hotel-tour' + newNum).change(function () {
        $.getJSON('/TourService/LoadPartner/' + $('#hotel-tour' + newNum).val(), function (data) {
            $('#code-hotel' + newNum).val(data.Code);
            $('#nguoi-lien-he-hotel' + newNum).val(data.StaffContact);
            $('#phone-hotel' + newNum).val(data.Phone);
        });
    });

    $("#hotel-tour" + newNum).select2();
    $("#currency-hotel-tour" + newNum).select2();
    $('#star-hotel' + newNum).select2();
    CKEDITOR.replace("note-hotel" + newNum);
    $('#deadline-status-hotel' + newNum + 1).select2();
    $('#deadline-currency-hotel' + newNum + 1).select2();
    CKEDITOR.replace("deadline-note-hotel" + newNum + 1);
}
function addNewDeadlineHotel(i) {
    var num = $('#OptionHotel' + i + ' .DeadlineHotel').length, // how many "duplicatable" input fields we currently have
        newNum = new Number(num + 1),      // the numeric ID of the new input field being added
        newElem = $('#DeadlineHotel' + i + num).clone().attr('id', 'DeadlineHotel' + i + newNum).fadeIn('slow'); // create the new element via clone(), and manipulate it's ID using newNum value
    // manipulate the name/id values of the input inside the new element

    newElem.find('.DeadlineTitle').html('Deadline ' + newNum);

    $('#DeadlineHotel' + i + num).find('.actions').remove();

    newElem.find('.deadline-name-hotel').attr('name', 'deadline-name-hotel' + i + newNum).attr('id', 'deadline-name-hotel' + i + newNum).val('');
    newElem.find('.deadline-total-hotel').attr('name', 'deadline-total-hotel' + i + newNum).attr('id', 'deadline-total-hotel' + i + newNum).val('');
    newElem.find('.deadline-thoigian-hotel').attr('id', 'deadline-thoigian-hotel' + i + newNum).attr('name', 'deadline-thoigian-hotel' + i + newNum).val('');
    newElem.find('.deadline-status-hotel').attr('id', 'deadline-status-hotel' + i + newNum).attr('name', 'deadline-status-hotel' + i + newNum);
    newElem.find('.deadline-currency-hotel').attr('id', 'deadline-currency-hotel' + i + newNum).attr('name', 'deadline-currency-hotel' + i + newNum);
    newElem.find('.deadline-note-hotel').attr('id', 'deadline-note-hotel' + i + newNum).attr('name', 'deadline-note-hotel' + i + newNum);

    newElem.find('.deadline-hotel-a').attr('data-target', '#deadline-hotel' + i + newNum);
    newElem.find('.deadline-hotel-body').attr('id', 'deadline-hotel' + i + newNum);

    newElem.find('.btnRemoveDealine').attr('onclick', 'removeDeadlineHotel(' + i + "," + newNum + ')');
    newElem.find('.btnRemoveDealine').attr('disabled', false);

    $('#DeadlineHotel' + i + num).after(newElem);
    $("#countDeadlineHotel" + i).val(newNum);

    newElem.find("#select2-deadline-status-hotel" + i + num + "-container").parent().parent().parent().remove();
    newElem.find("#select2-deadline-currency-hotel" + i + num + "-container").parent().parent().parent().remove();
    newElem.find("#cke_deadline-note-hotel" + i + num).remove();

    $('#deadline-status-hotel' + i + newNum).select2();
    $('#deadline-currency-hotel' + i + newNum).select2();
    CKEDITOR.replace("deadline-note-hotel" + i + newNum);
}
function removeOptionHotel() {
    var num = $('.OptionHotel').length,
        option = $('#OptionHotel' + (num - 1)),
        optionremove = $('#OptionHotel' + num),
        actions = $('#OptionHotel' + num).find('.actionsOption');
    if (num == 2)
        actions.find('.btnRemoveOption').attr('disabled', true);
    option.find('.captionOption').after(actions);
    optionremove.remove();
    $('#countOptionHotel').val(num - 1);
}
function removeDeadlineHotel(x, y) {

    var actions = $('#DeadlineHotel' + x + y).find('.actions').clone();
    actions.find('.btnRemoveDealine').attr('onclick', 'removeDeadlineHotel(' + x + "," + (y - 1) + ')');
    if (y == 2)
        actions.find('.btnRemoveDealine').attr('disabled', true);
    $('#DeadlineHotel' + x + (y - 1)).find('.caption').after(actions);
    $('#DeadlineHotel' + x + y).remove();
    $("#countDeadlineHotel" + x).val(y - 1);
}
//end khách sạn

//===========================================================================//

//Vận chuyển
$("#name-transport1").select2();
$("#ServiceCurrency11").select2();
CKEDITOR.replace("ServiceNote11");
/******** duplicate *******/
function addNewTranport() {
    var num = $('.OptionTransport').length, // how many "duplicatable" input fields we currently have
        newNum = new Number(num + 1),      // the numeric ID of the new input field being added
        newElem = $('#OptionTransport' + num).clone().attr('id', 'OptionTransport' + newNum).fadeIn('slow'); // create the new element via clone(), and manipulate it's ID using newNum value
    // manipulate the name/id values of the input inside the new element
    newElem.find('.OptionTitle').html('OPTION ' + newNum);

    newElem.find('.code-transport').attr('id', 'code-transport' + newNum).attr('name', 'code-transport' + newNum).val('');
    newElem.find('.name-transport').attr('id', 'name-transport' + newNum).attr('name', 'name-transport' + newNum);
    newElem.find('.nguoilienhe-transport').attr('id', 'nguoilienhe-transport' + newNum).attr('name', 'nguoilienhe-transport' + newNum).val('');
    newElem.find('.country-transport').attr('id', 'country-transport' + newNum).attr('name', 'country-transport' + newNum).val('');
    newElem.find('.phone-transport').attr('id', 'phone-transport' + newNum).attr('name', 'phone-transport' + newNum).val('');
    newElem.find('.file-transport').attr('id', 'file-transport' + newNum).val('');
    newElem.find('.OptionTransportA').attr('data-target', '#transport' + newNum);
    newElem.find('.OptionTransportBody').attr('id', 'transport' + newNum);
    newElem.find('.countDeadline').attr('id', 'countDeadlineTranport' + newNum).attr('name', 'NumberDeadlineTranport' + newNum).val(1);

    //service
    newElem.find('.ServiceTranport').attr('id', 'ServiceTranport' + newNum + 1);
    newElem.find('.btnNewServiceTranport').attr('onclick', 'addNewServiceTranport(' + newNum + ')');
    newElem.find('.btnRemoveServiceTranport').attr('onclick', 'removeServiceTranport(' + newNum + ',1)').attr('disabled', true);

    newElem.find('.ServiceCurrency').attr('id', 'ServiceCurrency' + newNum + 1).attr('name', 'ServiceCurrency' + newNum + 1);
    newElem.find('.ServiceName').attr('id', 'ServiceName' + newNum + 1).attr('name', 'ServiceName' + newNum + 1).val('');
    newElem.find('.ServicePrice').attr('id', 'ServicePrice' + newNum + 1).attr('name', 'ServicePrice' + newNum + 1).val('');
    newElem.find('.ServiceNote').attr('id', 'ServiceNote' + newNum + 1).attr('name', 'ServiceNote' + newNum + 1).val('');

    var arr = newElem.find('.ServiceTranport').toArray();
    newElem.find('.ServiceTranport').each(function (index) {
        if (arr.length - 1 != index)
            this.remove();
    });
    $('#OptionTransport' + num).after(newElem);
    $('#countOptionTransport').val(newNum);
    newElem.find('.btnRemoveOption').attr('disabled', false);
    $('#OptionTransport' + num).find('.actionsOption').remove();

    /******** upload file *******/
    $('#file-transport' + newNum).change(function () {
        var data = new FormData();
        data.append('TransportDocument', $('#file-transport' + newNum)[0].files[0]);
        data.append('id', newNum);

        var ajaxRequest = $.ajax({
            type: "POST",
            url: 'TourService/UploadFileTransport',
            contentType: false,
            processData: false,
            data: data
        });

        ajaxRequest.done(function (xhr, textStatus) {
            // Onsuccess
        });
    });
    $('#name-transport' + newNum).change(function () {
        $.getJSON('/TourService/LoadPartner/' + $('#name-transport' + newNum).val(), function (data) {
            $('#code-transport' + newNum).val(data.Code);
            $('#nguoilienhe-transport' + newNum).val(data.StaffContact);
            $('#phone-transport' + newNum).val(data.Phone);
        });
    });

    newElem.find("#select2-name-transport" + num + "-container").parent().parent().parent().remove();
    newElem.find("#cke_ServiceNote" + num + arr.length).remove();
    newElem.find("#select2-ServiceCurrency" + num + arr.length + "-container").parent().parent().parent().remove();

    $('#name-transport' + newNum).select2();
    $("#ServiceCurrency" + newNum + 1).select2();
    CKEDITOR.replace("ServiceNote" + newNum + 1);
}
function addNewServiceTranport(i) {
    var num = $('#OptionTransport' + i + ' .ServiceTranport').length, // how many "duplicatable" input fields we currently have
        newNum = new Number(num + 1),      // the numeric ID of the new input field being added
        newElem = $('#ServiceTranport' + i + num).clone().attr('id', 'ServiceTranport' + i + newNum).fadeIn('slow'); // create the new element via clone(), and manipulate it's ID using newNum value
    // manipulate the name/id values of the input inside the new element

    $('#ServiceTranport' + i + num).find('.btnRemoveServiceTranport').remove();

    newElem.find('.ServiceCurrency').attr('id', 'ServiceCurrency' + i + newNum).attr('name', 'ServiceCurrency' + i + newNum);
    newElem.find('.ServiceName').attr('name', 'ServiceName' + i + newNum).attr('id', 'ServiceName' + i + newNum).val('');
    newElem.find('.ServicePrice').attr('name', 'ServicePrice' + i + newNum).attr('id', 'ServicePrice' + i + newNum).val('');
    newElem.find('.ServiceNote').attr('id', 'ServiceNote' + i + newNum).attr('name', 'ServiceNote' + i + newNum);

    newElem.find('.btnRemoveServiceTranport').attr('onclick', 'removeServiceTranport(' + i + "," + newNum + ')');
    newElem.find('.btnRemoveServiceTranport').attr('disabled', false);
    newElem.find("#select2-ServiceCurrency" + i + num + "-container").parent().parent().parent().remove();
    $("#countDeadlineTranport" + i).val(newNum);
    $('#ServiceTranport' + i + num).after(newElem);
    $("#ServiceCurrency" + i + newNum).select2();
    newElem.find("#cke_ServiceNote" + i + num).remove();
    CKEDITOR.replace("ServiceNote" + i + newNum);
}
function removeOptionTransport() {
    var num = $('.OptionTransport').length,
        option = $('#OptionTransport' + (num - 1)),
        optionremove = $('#OptionTransport' + num),
        actions = $('#OptionTransport' + num).find('.actionsOption');
    if (num == 2)
        actions.find('.btnRemoveOption').attr('disabled', true);
    option.find('.captionOption').after(actions);
    $('#countOptionTransport').val(num - 1);
    optionremove.remove();
}
function removeServiceTranport(x, y) {
    var actions = $('#ServiceTranport' + x + y).find('.btnRemoveServiceTranport').clone();
    actions.attr('onclick', 'removeServiceTranport(' + x + "," + (y - 1) + ')');
    if (y == 2)
        actions.attr('disabled', true);
    $('#ServiceTranport' + x + (y - 1)).find('.actionRemoveServiceTranport').html(actions);
    $('#ServiceTranport' + x + y).remove();
    $("#countDeadlineTranport" + x).val(y - 1);
}
//end vận chuyển

//============================================================================//

//vé máy bay
$("#hang-plane1").select2();
$("#loaitien-plane1").select2();
$("#flight-plane1").select2();
CKEDITOR.replace("note-plane1");
$("#tinhtrang-deadline-plane11").select2();
$("#deadline-currency-plane11").select2();
CKEDITOR.replace("PlaneNoteDeadline11");
/******** duplicate *******/
function addNewOptionPlane() {
    var num = $('.OptionPlane').length,
        newNum = new Number(num + 1),
        newElem = $('#OptionPlane' + num).clone().attr('id', 'OptionPlane' + newNum).fadeIn('slow');

    newElem.find('.OptionTitle').html('OPTION ' + newNum);

    newElem.find('.contacter-plane').attr('id', 'contacter-plane' + newNum).attr('name', 'contacter-plane' + newNum).val('');
    newElem.find('.contacter-phone-plane').attr('id', 'contacter-phone-plane' + newNum).attr('name', 'contacter-phone-plane' + newNum).val('');
    newElem.find('.hang-plane').attr('id', 'hang-plane' + newNum).attr('name', 'hang-plane' + newNum);
    newElem.find('.quantity-plane1').attr('id', 'quantity-plane1' + newNum).attr('name', 'quantity-plane1' + newNum).val('');
    newElem.find('.code-plane').attr('id', 'code-plane' + newNum).attr('name', 'code-plane' + newNum).val('');
    newElem.find('.price-code').attr('id', 'price-code' + newNum).attr('name', 'price-code' + newNum).val('');
    newElem.find('.loaitien-plane').attr('id', 'loaitien-plane' + newNum).attr('name', 'loaitien-plane' + newNum);
    newElem.find('.flight-plane').attr('id', 'flight-plane' + newNum).attr('name', 'flight-plane' + newNum).val('');
    newElem.find('.note-plane').attr('id', 'note-plane' + newNum).attr('name', 'note-plane' + newNum);

    newElem.find('.OptionPlaneA').attr('data-target', '#plane' + newNum);
    newElem.find('.OptionPlaneBody').attr('id', 'plane' + newNum);

    newElem.find('.countDeadline').attr('id', 'countDeadlinePlane' + newNum).attr('name', 'NumberDeadlinePlane' + newNum).val(1);

    //deadline
    newElem.find('.DeadlinePlane').attr('id', 'DeadlinePlane' + newNum + 1);
    newElem.find('.DeadlineTitle').html('Deadline 1');

    newElem.find('.DeadlinePlaneA').attr('data-target', '#deadline-plane' + newNum + 1);
    newElem.find('.DeadlinePlaneBody').attr('id', 'deadline-plane' + newNum + 1);

    newElem.find('.btnAddNewDeadlinePlane').attr('onclick', 'addNewDeadlinePlane(' + newNum + ')');
    newElem.find('.btnRemoveDeadlinePlane').attr('onclick', 'removeDeadlinePlane(' + newNum + ',1)').attr('disabled', true);

    newElem.find('.name-deadline-plane').attr('id', 'name-deadline-plane' + newNum + 1).attr('name', 'name-deadline-plane' + newNum + 1).val('');
    newElem.find('.sotien-deadline-plane').attr('id', 'sotien-deadline-plane' + newNum + 1).attr('name', 'sotien-deadline-plane' + newNum + 1).val('');
    newElem.find('.thoigian-deadline-plane').attr('id', 'thoigian-deadline-plane' + newNum + 1).attr('name', 'thoigian-deadline-plane' + newNum + 1).val('');
    newElem.find('.tinhtrang-deadline-plane').attr('id', 'tinhtrang-deadline-plane' + newNum + 1).attr('name', 'tinhtrang-deadline-plane' + newNum + 1);
    newElem.find('.deadline-currency-plane').attr('id', 'deadline-currency-plane' + newNum + 1).attr('name', 'deadline-currency-plane' + newNum + 1);
    newElem.find('.file-deadline-plane').attr('id', 'file-deadline-plane' + newNum + 1).val('');
    newElem.find('.PlaneNoteDeadline').attr('id', 'PlaneNoteDeadline' + newNum + 1).attr('name', 'PlaneNoteDeadline' + newNum + 1);

    var arr = newElem.find('.DeadlinePlane').toArray();
    newElem.find('.DeadlinePlane').each(function (index) {
        if (arr.length - 1 != index)
            this.remove();
    });
    $('#OptionPlane' + num).after(newElem);
    $('#countOptionPlane').val(newNum);
    newElem.find('.btnRemoveOption').attr('disabled', false);
    $('#OptionPlane' + num).find('.actionsOption').remove();

    newElem.find("#select2-hang-plane" + num + "-container").parent().parent().parent().remove();
    newElem.find("#select2-loaitien-plane" + num + "-container").parent().parent().parent().remove();
    newElem.find("#select2-flight-plane" + num + "-container").parent().parent().parent().remove();
    newElem.find("#cke_note-plane" + num).remove();
    newElem.find("#select2-tinhtrang-deadline-plane" + num + arr.length + "-container").parent().parent().parent().remove();
    newElem.find("#select2-deadline-currency-plane" + num + arr.length + "-container").parent().parent().parent().remove();
    newElem.find("#cke_PlaneNoteDeadline" + num + arr.length).remove();

    $('#hang-plane' + newNum).select2();
    $('#loaitien-plane' + newNum).select2();
    $('#flight-plane' + newNum).select2();
    CKEDITOR.replace("note-plane" + newNum);
    $('#tinhtrang-deadline-plane' + newNum + 1).select2();
    $('#deadline-currency-plane' + newNum + 1).select2();
    CKEDITOR.replace("PlaneNoteDeadline" + newNum + 1);

    $('#hang-plane' + newNum).change(function () {
        $.getJSON('/TourService/LoadPartner/' + $('#hang-plane' + newNum).val(), function (data) {
            $('#code-plane' + newNum).val(data.Code);
            $('#contacter-plane' + newNum).val(data.StaffContact);
            $('#contacter-phone-plane' + newNum).val(data.Phone);
        });
    });
}
function addNewDeadlinePlane(i) {
    var num = $('#OptionPlane' + i + ' .DeadlinePlane').length,
        newNum = new Number(num + 1),
        newElem = $('#DeadlinePlane' + i + num).clone().attr('id', 'DeadlinePlane' + i + newNum).fadeIn('slow');

    $('#DeadlinePlane' + i + num).find('.actions').remove();

    newElem.find('.name-deadline-plane').attr('name', 'name-deadline-plane' + i + newNum).attr('id', 'name-deadline-plane' + i + newNum);
    newElem.find('.sotien-deadline-plane').attr('name', 'sotien-deadline-plane' + i + newNum).attr('id', 'sotien-deadline-plane' + i + newNum);
    newElem.find('.thoigian-deadline-plane').attr('id', 'thoigian-deadline-plane' + i + newNum).attr('name', 'thoigian-deadline-plane' + i + newNum);
    newElem.find('.tinhtrang-deadline-plane').attr('id', 'tinhtrang-deadline-plane' + i + newNum).attr('name', 'tinhtrang-deadline-plane' + i + newNum);
    newElem.find('.deadline-currency-plane').attr('id', 'deadline-currency-plane' + i + newNum).attr('name', 'deadline-currency-plane' + i + newNum);
    newElem.find('.file-deadline-plane').attr('id', 'file-deadline-plane' + i + newNum).attr('name', 'file-deadline-plane' + i + newNum);
    newElem.find('.PlaneNoteDeadline').attr('id', 'PlaneNoteDeadline' + i + newNum).attr('name', 'PlaneNoteDeadline' + i + newNum);

    newElem.find('.DeadlinePlaneA').attr('data-target', '#deadline-plane' + i + newNum);
    newElem.find('.DeadlinePlaneBody').attr('id', 'deadline-plane' + i + newNum);
    newElem.find('.DeadlineTitle').html('Deadline ' + newNum);
    $("#countDeadlinePlane" + i).val(newNum);

    newElem.find('.btnRemoveDeadlinePlane').attr('onclick', 'removeDeadlinePlane(' + i + "," + newNum + ')');
    newElem.find('.btnRemoveDeadlinePlane').attr('disabled', false);

    $('#DeadlinePlane' + i + num).after(newElem);

    /****** insert file ******/
    $('#file-deadline-plane' + i + num).change(function () {
        var data = new FormData();
        data.append('FileNamePlane', $('#file-deadline-plane' + i + num)[0].files[0]);
        data.append('id', i + num);

        var ajaxRequest = $.ajax({
            type: "POST",
            url: 'TourService/UploadFilePlane',
            contentType: false,
            processData: false,
            data: data
        });

        ajaxRequest.done(function (xhr, textStatus) {
            // Onsuccess
        });
    });

    newElem.find("#select2-deadline-currency-plane" + i + num + "-container").parent().parent().parent().remove();
    newElem.find("#select2-tinhtrang-deadline-plane" + i + num + "-container").parent().parent().parent().remove();
    newElem.find("#cke_PlaneNoteDeadline" + i + num).remove();
    CKEDITOR.replace("PlaneNoteDeadline" + i + newNum);
    $("#tinhtrang-deadline-plane" + i + newNum).select2();
    $("#deadline-currency-plane" + i + newNum).select2();
}
function removeOptionPlane() {
    var num = $('.OptionPlane').length,
       option = $('#OptionPlane' + (num - 1)),
       optionremove = $('#OptionPlane' + num),
       actions = $('#OptionPlane' + num).find('.actionsOption');
    if (num == 2)
        actions.find('.btnRemoveOption').attr('disabled', true);
    option.find('.captionOption').after(actions);
    $('#countOptionPlane').val(num - 1);
    optionremove.remove();
}
function removeDeadlinePlane(x, y) {
    var actions = $('#DeadlinePlane' + x + y).find('.actions').clone();
    actions.find('.btnRemoveDeadlinePlane').attr('onclick', 'removeDeadlinePlane(' + x + "," + (y - 1) + ')');
    if (y == 2)
        actions.find('.btnRemoveDeadlinePlane').attr('disabled', true);
    $('#DeadlinePlane' + x + (y - 1)).find('.caption').after(actions);
    $('#DeadlinePlane' + x + y).remove();
    $("#countDeadlinePlane" + x).val(y - 1);
}
//end vé máy bay

//===================================================================================//

function OnSuccessTourService() {
    CKupdate();
    $('form').trigger("reset");
    alert("Đã lưu!");
    $("#modal-insert-hotel").modal("hide");
    $("#modal-insert-restaurant").modal("hide");
    $("#modal-insert-event").modal("hide");
    $("#modal-insert-plane").modal("hide");
    $("#modal-insert-transport").modal("hide");
    $("#modal-insert-landtour").modal("hide");
    //
    $("#modal-edit-hotel").modal("hide");
    $("#modal-edit-restaurant").modal("hide");
    $("#modal-edit-event").modal("hide");
    $("#modal-edit-plane").modal("hide");
    $("#modal-edit-transport").modal("hide");
    $("#modal-edit-landtour").modal("hide");
}
function OnFailureTourService() {
    CKupdate();
    $('form').trigger("reset");
    alert("Lỗi. Vui lòng xem lại!");
    $("#modal-insert-hotel").modal("hide");
    $("#modal-insert-restaurant").modal("hide");
    $("#modal-insert-event").modal("hide");
    $("#modal-insert-plane").modal("hide");
    $("#modal-insert-transport").modal("hide");
    $("#modal-insert-landtour").modal("hide");
    //
    $("#modal-edit-hotel").modal("hide");
    $("#modal-edit-restaurant").modal("hide");
    $("#modal-edit-event").modal("hide");
    $("#modal-edit-plane").modal("hide");
    $("#modal-edit-transport").modal("hide");
    $("#modal-edit-landtour").modal("hide");
}

//===================================================================================//

function updateService(touroption, service, partner, servicepartner) {
    var dataPost = {
        touroption: touroption,
        service: service,
        partner: partner,
        servicepartner: servicepartner
    }
    switch (service) {
        //Nhà hàng
        case 1047:
            $.ajax({
                type: "POST",
                url: '/TourService/EditService',
                data: JSON.stringify(dataPost),
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                success: function (data) {
                    $("#info-detail-service").html(data);
                    $("#modal-edit-restaurant").modal("show");
                }
            });
            break;
        //Khách sạn
        case 1048:
            $.ajax({
                type: "POST",
                url: '/TourService/EditService',
                data: JSON.stringify(dataPost),
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                success: function (data) {
                    $("#info-detail-service").html(data);
                    $("#modal-edit-hotel").modal("show");
                }
            });
            break;
        //Hàng không
        case 1049:
            $.ajax({
                type: "POST",
                url: '/TourService/EditService',
                data: JSON.stringify(dataPost),
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                success: function (data) {
                    $("#info-detail-service").html(data);
                    $("#modal-edit-plane").modal("show");
                }
            });
            break;
        //Vận chuyển
        case 1050:
            $.ajax({
                type: "POST",
                url: '/TourService/EditService',
                data: JSON.stringify(dataPost),
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                success: function (data) {
                    $("#info-detail-service").html(data);
                    $("#modal-edit-transport").modal("show");
                }
            });
            break;
        //Event
        case 1051:
            $.ajax({
                type: "POST",
                url: '/TourService/EditService',
                data: JSON.stringify(dataPost),
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                success: function (data) {
                    $("#info-detail-service").html(data);
                    $("#modal-edit-event").modal("show");
                }
            });
            break;
    }
}