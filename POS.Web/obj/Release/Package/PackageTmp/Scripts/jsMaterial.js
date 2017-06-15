$(document).ready(function () {
    ///Search for  Store / Location / LocationID -Srikanth
    $('#txtMaterials').keyup(function () {
        $('.MlocData').hide();
        $('#NoRecords').hide();
        var searchText = $('#txtMaterials').val().toLocaleLowerCase();
        var txtLength = searchText.length;
        var searchExists = false;
        if (txtLength >= 2) {
            $('.MlocData').each(function () {
                var locText = $(this).html();
                if (locText.toLowerCase().indexOf(searchText) >= 0) {
                    $(this).show();
                    searchExists = true;
                }
            });
            if (!searchExists) {
                $('#NoRecords').show();
            }
        }
        else {
            $('.MlocData').show();
        }
    });
    var i;
    ///On selecting location/store get details by id -Vinod
    $(".MasterMStore").click(function () {
        var MaterialID = $(this).attr('data-MaterialID');
        $.ajax({
            url: '../Material/GetMaterialById',
            data: { 'MaterialID': MaterialID },
            type: "post",
            cache: false,
            success: function (data) {
                var datalength = $(data).length;
                if (datalength > 1) {
                    for (i = 1; i < datalength; i++) {
                        $.ajax({
                            url: '../Material/NewMaterialEntries',
                            data: { 'index': i },
                            type: "post",
                            cache: false,
                            success: function (data) {
                                $('#NewRows').append(data);
                                $('#Valueindex').val(i);
                                i++;
                            },
                            error: function (xhr, ajaxOptions, thrownError) {
                                var type = BootstrapDialog.TYPE_WARNING;
                                BootstrapDialog.show({
                                    type: type,
                                    title: 'Error',
                                    message: 'Error in geting New Material EAN data from server. Please try again.'
                                });
                            }
                        });
                    }
                    $('#MaterialDetails').html(data);

                }



            },
            error: function (xhr, ajaxOptions, thrownError) {
                var type = BootstrapDialog.TYPE_WARNING;
                BootstrapDialog.show({
                    type: type,
                    title: 'Error',
                    message: 'Error in geting Material data from server. Please try again.'
                });
            }
        });
    });
    $("#btnNewMTerminal").click(function () {
        var locID = $(this).attr('data-MaterialID');
        $.ajax({
            url: '../Material/GetMaterialById',
            data: { 'MaterialID': null },
            type: "post",
            cache: false,
            success: function (data) {
                $('#MaterialDetails').html(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var type = BootstrapDialog.TYPE_WARNING;
                BootstrapDialog.show({
                    type: type,
                    title: 'Error',
                    message: 'Error in geting New Material data from server. Please try again.'
                });
            }
        });
    });
    $("#TRPreferUOM").keypress(function (event) {
        if (event.keyCode == 13) {
            var _for = $(this).closest('tr');
            if (_for.find('input:text').length >= 1) {
                $(this).appendTo('#NewRows');
            }
            else {
                var type = BootstrapDialog.TYPE_WARNING;
                BootstrapDialog.show({
                    type: type,
                    title: 'Error',
                    message: 'Error'
                });
                alert(_for.find('input:text').length)
            }
        }
    });
    var indx = 1;
    $("#NewMaterialEAN").click(function () {
        $.ajax({
            url: '../Material/NewMaterialEntries',
            data: { 'index': indx },
            type: "post",
            cache: false,
            success: function (data) {
                $('#NewRows').append(data);
                $('#Valueindex').val(indx);
                indx++;
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var type = BootstrapDialog.TYPE_WARNING;
                BootstrapDialog.show({
                    type: type,
                    title: 'Error',
                    message: 'Error in geting New Material EAN data from server. Please try again.'
                });
            }
        });

    });
    $("#btnSaveMaterialDetails").click(function () {
        $('#NewRows input').each(function () {
            if ($(this).val() == '') {
                $(this).css('border', '1px solid red');
            }
            else {
                $(this).css('border', '1px solid #cccccc');
            }
        });

    });

    $("#FileUpload").addClass("glyphicon glyphicon-plus");

    $('.tables').click(function () {
        var CurrentID = $(this).attr('id');
        alert(CurrentID);
        var id = $(this).closest('table').attr('id');
        alert(id);
        $('#' + id).remove();
        indx--;
    });

});