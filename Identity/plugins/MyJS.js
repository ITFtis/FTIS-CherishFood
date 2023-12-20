$(function () {
    $('.daterange').daterangepicker({
        autoUpdateInput: false,
        locale:
        {
            format: 'YYYY/MM/DD',
            cancelLabel: 'Clear',
            applyLabel: '確認',
            cancelLabel: '取消',
            daysOfWeek: ['一', '二', '三', '四', '五', '六', '日'],
            monthNames: ['一月', '二月', '三月', '四月', '五月', '六月',
                '七月', '八月', '九月', '十月', '十一月',
                '十二月']
        }
    });

    $('.daterange').on('apply.daterangepicker', function (ev, picker) {
        $(this).val(picker.startDate.format('YYYY/MM/DD') + ' - ' + picker.endDate.format('YYYY/MM/DD'));
    });

    $('.daterange').on('cancel.daterangepicker', function (ev, picker) {
        $(this).val('');
    });
    $(".form_date").datepicker({
        format: 'yyyy-mm-dd',
        autoclose: true

    });
    $('.datetimepicker').datetimepicker({
        format: 'yyyy-mm-dd hh:ii',
        autoclose: true

    });
    $(".form_datetime").datetimepicker({
        format: 'yyyy-mm-dd hh:ii',
        autoclose: true
    });

    //Initialize Select2 Elements
    $(".select2").select2();

    $(".ddlselect").select2();
    //$('<%= "#"+form1.ClientID%>').validator();
    //$('input[type="checkbox"], input[type="radio"]').iCheck({
    //    checkboxClass: 'icheckbox_flat-green',
    //    radioClass: 'iradio_flat-green'
    //});

    var opt = {
        "oLanguage": {
            "sProcessing": "處理中...",
            "sLengthMenu": "顯示 _MENU_ 項結果",
            "sZeroRecords": "沒有匹配結果",
            "sInfo": "顯示第 _START_ 至 _END_ 項結果，共 _TOTAL_ 項",
            "sInfoEmpty": "顯示第 0 至 0 項結果，共 0 項",
            "sInfoFiltered": "(從 _MAX_ 項結果過濾)",
            "sSearch": "搜索:",
            "oPaginate": {
                "sFirst": "首頁",
                "sPrevious": "上頁",
                "sNext": "下頁",
                "sLast": "尾頁"
            }
        },
        "bPaginate": true,
        "bLengthChange": true,
        "bFilter": true,
        "bSort": true,
        "bInfo": true,
        "bAutoWidth": true,
        order: [],
    };
    $('.dataTables').on('processing.dt', function (e, settings, processing) {
        $.unblockUI();
    }).DataTable(opt);

    //Date picker
    $('[data-toggle="tooltip"]').tooltip();

    //將預設語系設定為中文
    $('.datepicker').datepicker({
        autoclose: true,
        dateFormat: 'yyyy-mm-dd',
        //language: 'zh-TW'
    });



    $('.resultList').click(function () {
        var isreload = $(this).data('reload');
        var hrf = $(this).data('href');
        var id = $(this).data('id');
        var oid = $(this).data('oid');
        var str = "";
        if (typeof id != "undefined") {
            str = "id=" + id;
        }
        if (typeof oid != "undefined") {
            if (str != "") {
                str += "&";
            }
            str += "oid=" + oid;
        }
        if (str != "") {
            hrf = hrf + "?" + str;
        }
        $.fancybox.open({
            href: hrf,
            type: 'iframe',
            overlayShow: true,
            padding: 20,
            scrolling: 'auto',
            fitToView: true,
            helpers: {
                overlay: { closeClick: false }
            },
            autoScale: true,
            closeClick: false,
            showCloseButton: true,
            onUpdate: function () {
                $("iframe.fancybox-iframe");
            },
            afterClose: function () {
                if (isreload) {
                    location.reload();
                    return;
                }
            }
        });
    });

    $('.resultListSer').click(function () {
        var isreload = $(this).data('reload');
        var hrf = $(this).data('href');
        var ono = $(this).data('ono');
        var cid = $(this).data('cid');
        var otype = $(this).data('otype');
        var str = "";
        if (typeof ono != "undefined") {
            str = "ono=" + ono;
        }
        if (typeof cid != "undefined") {
            if (str != "") {
                str += "&";
            }
            str += "cid=" + cid;
        }
        if (typeof otype != "undefined") {
            if (str != "") {
                str += "&";
            }
            str += "otype=" + otype;
        }
        if (str != "") {
            hrf = hrf + "?" + str;
        }
        $.fancybox.open({
            href: hrf,
            type: 'iframe',
            overlayShow: true,
            padding: 20,
            scrolling: 'auto',
            fitToView: true,
            helpers: {
                overlay: { closeClick: false }
            },
            autoScale: true,
            closeClick: false,
            showCloseButton: true,
            onUpdate: function () {
                $("iframe.fancybox-iframe");
            },
            afterClose: function () {
                if (isreload) {
                    location.reload();
                    return;
                }
            }
        });
    });
});
function getFiles(type, cName, dir) {
    var files = [];
    $.ajax({
        url: "FileGetHandler.ashx?files=" + escape($('#' + cName).val()) + "&dir=" + dir,
        dataType: "json",
        type: 'POST',
        async: false,
        success: function (data) {
            if (type == "initialPreview") {
                $.each(data.initialPreview, function (i, v) {
                    files.push(v);
                });
            }
            if (type == "initialPreviewConfig") {
                $.each(data.initialPreviewConfig, function (i, v) {
                    files.push(v);
                });
            }

        }
    });
    return files;
};

$(document).ready(function () {

    $(".Sinputfiles").each(function () {
        $(this).next('input').hide();
        var dirpath = $(this).data("dir");
        var allExtensions = $(this).data("ext").split(',');
        var maxSize = $(this).data("maxsize");
        if (!maxSize) maxSize = 0;
        var ctr = $(this).next('input').attr('id');
        $(this).fileinput(
            {
                language: 'zh-TW', //设置语言
                uploadUrl: "FileUploadHandler.ashx",
                uploadAsync: true,
                overwriteInitial: true,
                showUpload: false, //是否顯示上傳按鈕
                showRemove: false,//是否顯示移除按鈕
                maxFileCount: 1, //表示允許同時上傳的最大文件個數
                maxFileSize: maxSize,//單位為kb,0表示不受限制
                initialPreviewAsData: true, //識別是否只發送預覽數據,而不是原始標記  
                initialPreviewFileType: 'image',
                initialPreview: getFiles('initialPreview', ctr, dirpath),
                initialPreviewConfig: getFiles('initialPreviewConfig', ctr, dirpath),
                deleteUrl: "FileDeleteHandler.ashx",
                allowedFileExtensions: allExtensions, // 接收的文件後綴
                uploadExtraData: function () {
                    return {
                        key: '',
                        dir: dirpath
                    };
                },
            }).on("filebatchselected", function (event, files) {
                $(this).fileinput("upload");
            }).on("fileuploaded", function (event, data, previewId, index) {
                var img = data.response.initialPreviewConfig[0];
                $('#' + ctr).val(img.key);
            }).on('filepredelete', function (event, data) {
                var words = $('#' + ctr).val().split(',');
                words = jQuery.grep(words,
                    function (value) {
                        return value !== data;
                    });
                $('#' + ctr).val(words);
            });

    });

    $(".Vinputfiles").each(function () {
        $(this).next('input').hide();
        var dirpath = $(this).data("dir");
        var ctr = $(this).next('input').attr('id');
        $(this).fileinput(
            {
                language: 'zh-TW', //设置语言
                uploadUrl: "FileUploadHandler.ashx",
                uploadAsync: true,
                overwriteInitial: true,
                showUpload: false, //是否顯示上傳按鈕
                showRemove: false,//是否顯示移除按鈕
                maxFileCount: 1, //表示允許同時上傳的最大文件個數
                maxFileSize: 0,//單位為kb,0表示不受限制
                initialPreviewAsData: true, //識別是否只發送預覽數據,而不是原始標記  
                initialPreview: getFiles('initialPreview', ctr, dirpath),
                initialPreviewConfig: getFiles('initialPreviewConfig', ctr, dirpath),
                deleteUrl: "FileDeleteHandler.ashx",
                allowedFileExtensions: ['mp4', 'mpg'], // 接收的文件後綴 
                uploadExtraData: function () {
                    return {
                        key: '',
                        dir: dirpath
                    };
                },
            }).on("filebatchselected", function (event, files) {
                $(this).fileinput("upload");
            }).on('filebatchuploaderror', function (event, data, msg) {
                $(".file-error-message").text("請按照正常的操作！謝謝！");
            })
            .on("fileuploaded", function (event, data, previewId, index) {



                var img = data.response.initialPreviewConfig[0];
                $('#' + ctr).val(img.key);
            }).on('filepredelete', function (event, data) {
                var words = $('#' + ctr).val().split(',');
                words = jQuery.grep(words,
                    function (value) {
                        return value !== data;
                    });
                $('#' + ctr).val(words);
            });
    });
    $(".modeimg").on('click', function () {
        var Mimg = $(this).next('input').val($(this).attr('id'));
        $("#input-b9").fileinput('destroy');
        $("#input-b9").fileinput({
            showPreview: false,
            showUpload: false,
            elErrorContainer: '#kartik-file-errors',
            initialPreviewFileType: 'image',
            uploadUrl: "FileUploadHandler.ashx",
            uploadAsync: true,
            uploadExtraData: function () {
                return {
                    key: '',
                    dir: 'Products'
                };
            }
        })
            .on("filebatchselected", function (event, files) {
                $(this).fileinput("upload");
            }).on("fileuploaded", function (event, data, previewId, index) {
                var img = data.response.initialPreviewConfig[0];
                var Mthis = $('#' + Mimg.val());
                Mthis.attr('src', '../WPContent/Uploads/' + img.key);
                Mthis.parent().find('input').val(img.key);
                $('#SUploadModal').modal('hide');
            });
    });

    $(".Minputfiles").each(function () {
        $(this).next('input').hide();
        var dirpath = $(this).data("dir");
        var widthtb = $(this).data("width");
        if (typeof (widthtb) === "undefined") {
            widthtb = ''
        }
        var ctr = $(this).next('input').attr('id');
        $(this).fileinput(
            {
                theme: 'fa',
                language: 'zh-TW', //设置语言
                uploadUrl: "FileUploadHandler.ashx",
                uploadAsync: true,
                overwriteInitial: false,
                showUpload: false, //是否顯示上傳按鈕
                showRemove: false,//是否顯示移除按鈕
                maxFileCount: 0, //表示允許同時上傳的最大文件個數
                maxFileSize: 0,//單位為kb,0表示不受限制
                initialPreviewFileType: 'image',
                initialPreviewAsData: true, //識別是否只發送預覽數據,而不是原始標記  
                initialPreview: getFiles('initialPreview', ctr, dirpath),
                initialPreviewConfig: getFiles('initialPreviewConfig', ctr, dirpath),
                deleteUrl: "FileDeleteHandler.ashx",
                uploadExtraData: function () {
                    return {
                        dir: dirpath,
                        width: widthtb
                    };
                }
            }).on("filebatchselected", function (event, files) {
                $(this).fileinput("upload");
            }).on("fileuploaded", function (event, data, previewId, index) {

                var img = data.response.initialPreviewConfig[0];
                var words = $('#' + ctr).val().split(',');
                if (img.key.length > 0) {
                    console.log(img.key);
                    words.push(img.key);
                    $('#' + ctr).val(words.filter(function (v) { return v !== '' }).join(','));
                }
            }).on('filepredelete', function (event, data) {
                var words = $('#' + ctr).val().split(',');
                words = jQuery.grep(words,
                    function (value) {
                        return value !== data;
                    });
                $('#' + ctr).val(words);
            }).on('filesorted', function (e, params) {
                var words = [];
                $.each(params.stack, function (index, value) {
                    words.push(value["key"]);
                });
                $('#' + ctr).val(words.join(','));
                console.log('File sorted params', params);
            });
    });
});
function getParameterByName(name, url) {
    if (!url) {
        url = window.location.href;
    }
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}
