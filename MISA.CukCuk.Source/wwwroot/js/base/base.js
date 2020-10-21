$(document).ready(function () {
    /**
    * Author: NKĐạt
    * Date: 28/9/2020
    * Timeout Event Responsive Menu
    * */
    var timeout;
    $(window).resize(function () {
        if (timeout) clearTimeout(timeout);
        timeout = setTimeout(menu_responsive, 10);
    });
})

class BaseJS {
    constructor() {
        try {
            this.offset = 0;
            this.pageSize = $('#pageSize').val();
            this.getDataPaging(0, this.pageSize);
            this.getDataCount();
            this.getDepartment();
            this.getPosition();
            this.loadData();
            this.initEvents();
            this.FormMode = null;
            this.checkRequired = null;
            this.selectId = null;
            this.SaveAdd = null;
            this.Dialog = null;
        } catch (e) {
            console.log(e);
        }
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * Gán các sự kiện thành phần
    * */
    initEvents() {
        //Các nút và thành phần thêm, sửa, xóa, hủy bỏ.
        $('#btnAdd').click(this.btnAddOnClick.bind(this));
        $('#btnEdit').click(this.btnEditOnClick.bind(this));
        $('#btnDelete').click(this.btnDeleteOnClick.bind(this));
        $('#btnReset').click(this.btnResetOnClick.bind(this));
        $('#btnDuplicate').click(this.btnDuplicateOnClick.bind(this));
        $('#btnClose').click(this.closeDialogOnClick.bind(this));
        $('#btnSave').click(this.btnSaveOnClick.bind(this));
        $('#btnSaveAdd').click(this.btnSaveAddOnClick.bind(this));
        $('#btnCancel').click(this.closeDialogOnClick.bind(this));
        $('#btnHelpDialog').blur(this.returnFocus);
        //Validate yêu cầu
        $('input[required]').blur(this.validateRequired.bind(this));
        //Select Hàng
        $("table tbody").on("click", "tr", this.rowOnSelect);
        //Các btn phân trang 
        $('#btnFirst').click(this.btnFirstOnClick.bind(this));
        $('#btnPrev').click(this.btnPrevOnClick.bind(this));
        $('#btnNext').click(this.btnNextOnClick.bind(this));
        $('#btnLast').click(this.btnLastOnClick.bind(this));
        $('#pageSize').on("change", this.pageSizeOnChange.bind(this));
        //Responsive Menu
        $('#slideMenu').click(this.slideOnClick.bind(this));
        $('.main').click(this.mainPageOnClick.bind(this));
        //Ẩn Dialog
        $('.dialog-modal').click(this.closeDialogOnClick.bind(this));
        $('.dialog-modal-announce').click(this.closeDialogAnnounceOnClick.bind(this));
        //Dialog xác nhận 
        $('#btnCloseConfirm').click(this.closeDialogConfirmOnClick.bind(this));
        $('#btnConfirmAnnounce').click(this.closeDialogAnnounceOnClick.bind(this));
        $('#btnAgreeConfirm').click(this.agreeOnClick.bind(this));
        $('#btnCancelConfirm').click(this.closeDialogConfirmOnClick.bind(this));
        //Dialog thông báo
        $('#btnCloseAnnounce').click(this.closeDialogAnnounceOnClick.bind(this));
        //Dialog cảnh báo
        $('#btnCloseWarning').click(this.closeDialogWarningOnClick.bind(this));
        $('#btnConfirmWarning').click(this.closeDialogWarningOnClick.bind(this));
        //Event Keyup Format Money
        $('#txtMoneyTax').on('blur, focus, keyup', this.formatMoneyKeyup);
        $('#txtSalary').on('blur, focus, keyup', this.formatMoneyKeyup);
        //Event phím tắt
        $(document).keydown(this.keydownclose.bind(this));
        $(document).keydown(this.keydowncancel.bind(this));
        $(document).keydown(this.keydownsaveadd.bind(this));
        $(document).keydown(this.keydownsave.bind(this));
    }

    getDataPaging() {
        this.Data = [];
    }

    /**
    * Author: NKĐạt
    * Date: 21/10/2020
    * Cập nhật thay đổi số lượng bản ghi hiện lên
    * */
    pageSizeOnChange() {
        this.pageSize = $('#pageSize').val();
        this.getDataPaging(0, this.pageSize);
        this.loadData();
        this.offset = 0;
        $('#totalStart').text(1);
        $('#totalEnd').text(this.pageSize);
        $('#numPage').val(1);
        if (parseInt(this.DataCount % this.pageSize) == 0)
            $('#numTotal').text(parseInt(this.DataCount / this.pageSize));
        else
            $('#numTotal').text(parseInt(this.DataCount / this.pageSize) + 1);
    }

    /**
    * Author: NKĐạt
    * Date: 21/10/2020
    * Mở trang paging đầu tiên
    * */
    btnFirstOnClick() {
        this.getDataPaging(0, this.pageSize);
        this.loadData();
        $('#totalStart').text(1);
        $('#totalEnd').text(this.pageSize);
        $('#numPage').val(1);
        this.offset = 0;
    }

    /**
    * Author: NKĐạt
    * Date: 21/10/2020
    * Mở trang paging cuối cùng
    * */
    btnLastOnClick() {
        var maxTotal = parseInt(this.DataCount / this.pageSize);
        if (parseInt(this.DataCount % this.pageSize) != 0)
            maxTotal += 1;
        $('#numTotal').text(maxTotal);
        this.offset = (maxTotal - 1) * this.pageSize;
        this.getDataPaging(this.offset, this.pageSize);
        this.loadData();
        $('#totalStart').text(this.offset);
        $('#totalEnd').text(this.DataCount);
        $('#numPage').val(maxTotal);
    }

    /**
    * Author: NKĐạt
    * Date: 21/10/2020
    * Mở trang paging tiếp theo
    * */
    btnNextOnClick() {
        var currentPageNumber = $('#numPage').val();
        var total = parseInt(currentPageNumber);
        var maxTotal = parseInt(this.DataCount / this.pageSize);
        if (parseInt(this.DataCount % this.pageSize) != 0)
            maxTotal += 1;
        if (currentPageNumber && currentPageNumber < maxTotal) {
            $('#numPage').val(total + 1);
            this.getDataPaging(total * this.pageSize, this.pageSize);
            this.loadData();
            $('#totalStart').text(total * this.pageSize);
            if (currentPageNumber == (maxTotal - 1))
                $('#totalEnd').text(this.DataCount);
            else
                $('#totalEnd').text((total + 1) * this.pageSize);
            this.offset = total * this.pageSize;
        }
    }

    /**
    * Author: NKĐạt
    * Date: 21/10/2020
    * Mở trang paging trước đó
    * */
    btnPrevOnClick() {
        var currentPageNumber = $('#numPage').val();
        var total = parseInt(currentPageNumber);
        if (currentPageNumber && total > 1) {
            $('#numPage').val(total - 1);
            this.getDataPaging((total - 2) * this.pageSize, this.pageSize);
            this.loadData();
            if (total == 2) {
                $('#totalStart').text(1);
            } else
                $('#totalStart').text((total - 2) * this.pageSize);
            $('#totalEnd').text((total - 1) * this.pageSize);
            this.offset = (total - 2) * this.pageSize;
        }
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * Lấy dữ liệu và Binding dữ liệu lên trên UI
    * */
    loadData() {
        try {
            // Đọc thông tin các cột dữ liệu:
            var fields = $('#tblListData thead th');
            var self = this;
            //#region THÔNG TIN BẢN GHI
            var maxTotal = parseInt(this.DataCount / this.pageSize);
            if (parseInt(this.DataCount % this.pageSize) != 0)
                maxTotal += 1;
            if ($('#numPage').val() == maxTotal)
                $('#totalEnd').text(this.DataCount);
            $('#numTotal').text(maxTotal);
            $('#countTotal').text(self.DataCount);
            //#endregion
            // Lấy dữ liệu:
            var data = self.Data;
            $('#tblListData tbody').empty();
            //console.log(data);
            $.each(data, function (index, item) {
                var tr = $(`<tr></tr>`);
                $.each(fields, function (index, field) {
                    //Lấy dữ liệu từ các cột
                    var fieldName = $(field).attr('fieldName');
                    var format = $(field).attr('format');
                    var value = item[fieldName];
                    if (format == "Date") {
                        if (value == null) 
                            var td = $(`<td>` + "" + `</td>`);
                        else
                            var td = $(`<td style="text-align: center;">` + dateToDMY(new Date(value)) + `</td>`);
                    } else if (format == "Money") {
                        var td = $(`<td style="text-align: right;">` + value.formatMoney() + `</td>`);
                    } else {
                        var td = $(`<td>` + value + `</td>`);
                    }
                    $(tr).append(td);
                    $(tr).data('key', item[Object.keys(item)[0]]);
                    $(tr).data('code', item[Object.keys(item)[1]]);
                })
                // Binding dữ liệu lên trên UI
                $('#tblListData tbody').append(tr);
            });
        } catch (e) {
            console.log(e)
        }
    }

    /**
     * Author: NKĐạt
     * @param {object} objInput
     * @param {string} method
     * Call ajax hàm postdata
     */
    postData(objInput, method) { };

    /**
     * Author: NKĐạt
     * @param {string} selectDel
     * Call ajax hàm deletedata
     */
    deleteData(selectDel) { };

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * Hiển thị dialog chi tiết thông tin
    * */
    btnAddOnClick() {
        this.FormMode = "add";
        this.getNewCode(true);
        this.showDialogDetail();
        this.SaveAdd = null;
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * Check và lưu dữ liệu
    * */
    btnSaveOnClick() {
        try {
            //Vaildate dữ liệu nhập vào (Kiểm tra dữ liệu có đúng hay không)
            var inputRequireds = $("[required]");
            var isValid = true;
            var self = this;
            var method = "POST";
            $.each(inputRequireds, function (index, input) {
                if (!validData.validateRequired(input)) {
                    isValid = false;
                }
            })
            if (isValid)
                isValid = self.validateCustom();
            if (isValid) {
                // Đọc thông tin các ô dữ liệu:
                var fields = $('.dialog input, .dialog select, .dialog textarea');
                var objInput = new Object();
                var nameId = Object.keys(self.Data[0])[0];
                nameId = upperCaseFirstLetter(nameId);
                objInput[nameId] = "00000000-0000-0000-0000-000000000000";
                $.each(fields, function (index, field) {
                    var fieldName = $(field).attr('fieldName');
                    var format = $(field).attr('format');
                    if (format == "Int") {
                        objInput[fieldName] = parseInt($(field).val());
                    }
                    else
                        objInput[fieldName] = $(field).val();
                    if (format == "Money") {
                        if (objInput[fieldName] == "") {
                            objInput[fieldName] = parseFloat(0);
                        } else {
                            objInput[fieldName] = parseFloat($(field).val().replaceAll('.', ''));
                        }
                    } else if (format == "Date") {
                        if (objInput[fieldName] == "") {
                            objInput[fieldName] = null;
                        } else {
                            objInput[fieldName] = $(field).val();
                        }
                    }
                })
                //Thực hiện cất dữ liệu vào DataBase;
                if (self.FormMode == "edit") {
                    method = "PUT";
                    objInput[nameId] = self.selectId;
                }
                self.postData(objInput, method);
            }
        } catch (e) {
            console.log(e)
        }
    }

    /**
    * Author: NKĐạt
    * Date: 3/10/2020
    * Cất và thêm dữ liệu
    * */
    btnSaveAddOnClick() {
        this.SaveAdd = "SaveAdd";
        this.btnSaveOnClick();
    }

    /**
    * Author: NKĐạt
    * Date: 3/10/2020
    * Sửa dữ liệu
    * */
    btnEditOnClick() {
        try {
            // Lấy dữ liệu của nhân viên tương ứng đã chọn:
            // 1. Xác định nhân viên nào được chọn:
            var trSelected = $("#tblListData tr.row-selected");
            var self = this;
            self.FormMode = "edit";
            // 2. Lấy thông tin Mã nhân viên:
            if (trSelected.length > 0) {
                self.showDialogDetail();
                self.selectId = trSelected.data('key');
                // 3. Gọi api service để lấy dữ liệu chi tiết của nhân viên với mã tương ứng:
                self.getDataDetail(self.selectId);
                var objDetail = self.DataDetail;
                if (!objDetail) {
                    self.showDialogWarning('none');
                } else {
                    // bindding các thông tin của nhân viên lên form:
                    var fields = $('.dialog input, .dialog select, .dialog textarea');
                    $.each(fields, function (index, field) {
                        var fieldName = $(field).attr('fieldName');
                        fieldName = lowerCaseFirstLetter(fieldName);
                        var format = $(field).attr('format');
                        if (format == "Money") {
                            field.value = objDetail[fieldName].formatMoney();
                        } else if (format == "Date") {
                            if (objDetail[fieldName] == null)
                                field.value = "";
                            else
                                field.value = dateToYMD(new Date(objDetail[fieldName]));
                        } else {
                            field.value = objDetail[fieldName];
                        }
                    })
                }
            } else {
                self.showDialogWarning('no-select');
            }
        } catch (e) {
            console.log(e)
        }
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * Nhân bản nhân viên
    * */
    btnDuplicateOnClick() {
        try {
            // Lấy dữ liệu của nhân viên tương ứng đã chọn:
            // 1. Xác định nhân viên nào được chọn:
            var trSelected = $("#tblListData tr.row-selected");
            var self = this;
            var method = "POST";
            var nameId = Object.keys(self.Data[0])[0];
            var nameCode = Object.keys(self.Data[0])[1];
            // 2. Lấy thông tin Mã nhân viên:
            if (trSelected.length > 0) {
                self.selectId = trSelected.data('key');
                // 3. Gọi api service để lấy dữ liệu chi tiết của nhân viên với mã tương ứng:
                self.getDataDetail(self.selectId);
                var objDetail = self.DataDetail;
                if (!objDetail) {
                    self.showDialogWarning('none');
                } else {
                    // Tạo id mới và mã code mới
                    objDetail[nameId] = "00000000-0000-0000-0000-000000000000";
                    self.getNewCode(false);
                    objDetail[nameCode] = self.newCode;
                    //Thực hiện cất dữ liệu vào DataBase;
                    self.postData(objDetail, method);
                }
            } else {
                self.showDialogWarning('no-select');
            }
        } catch (e) {
            console.log(e)
        }
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * Xóa dữ liệu
    * */
    btnDeleteOnClick() {
        try {
            var self = this;
            self.checkRequired = false;
            // Lấy mã nhân viên được chọn:
            var trSelected = $("#tblListData tr.row-selected");
            // Gọi API service thực hiện:
            self.selectCode = trSelected.data('code');
            var listDel = [];
            if (trSelected.length > 0) {
                trSelected.each((i, e) => {
                    listDel.push($(e).data('code'));
                })
                self.selectDel = listDel.join();
                if (trSelected.length == 1)
                    self.showDialogConfirm('del-1');
                else
                    self.showDialogConfirm('del-n');
            } else {
                self.showDialogWarning('no-select');
            }
        } catch (e) {
            console.log(e)
        }
    }

    /**
    * Author: NKĐạt
    * Date: 19/10/2020
    * Reset dữ liệu
    * */
    btnResetOnClick() {
        this.getDataPaging(this.offset, this.pageSize);
        this.loadData();
    }

    /**
    * Author: NKĐạt
    * Date: 6/10/2020
    * Button Agree Dialog Confirm
    * */
    agreeOnClick() {
        self.deleteData(self.selectDel);
    }

    /**
    * Author: NKĐạt
    * Date: 6/10/2020
    * Hiện dialog thông báo
    * @param {string} check
    * */
    checkDialogConfirm(check) {
        $('.dialog-confirm').hide();
        if (check == true) {
            $('#txtTitleAnnounce').text('Xóa thành công!');
        } else {
            $('#txtTitleAnnounce').text('Không có nhân viên với mã tương ứng!');
        }
        $('.dialog-announce').show();
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * Event Ẩn Dialog FormMode
    * */
    closeDialogOnClick() {
        this.hideDialogDetail();
        this.FormMode = null;
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * Event Ẩn Dialog Thông Báo
    * */
    closeDialogAnnounceOnClick() {
        self = this;
        this.hideDialogAnnounce();
        this.hideDialogConfirm();
        this.hideDialogWarning();
        if (self.SaveAdd == "SaveAdd")
            self.btnAddOnClick();
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * Event Ẩn Dialog Xác Nhận
    * */
    closeDialogConfirmOnClick() {
        this.hideDialogConfirm();
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * Event Ẩn Dialog Cảnh Báo
    * */
    closeDialogWarningOnClick() {
        this.hideDialogWarning();
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * Hiện Dialog Thông Tin Khi Click
    * */
    showDialogDetail() {
        $('.dialog input, .dialog textarea, .dialog select').val(null);
        $('.dialog-modal').show();
        $('.dialog').show();
        $('#txtCustomerCode').focus();
        var selects = $(".dialog select");
        $.each(selects, function (index, select) {
            $("option:first-child").prop("selected", true);
        })
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * Hiện Dialog Xác Nhận Xóa Khi Click
    * */
    showDialogConfirm(checkValue) {
        self = this;
        $('.dialog-modal-announce').show();
        if (checkValue == 'del-1') {
            $('#txtTitleConfirm').text('Bạn chắc chắn muốn xóa Nhân viên <<' + self.selectCode + '>> không ?');
        } else if (checkValue == 'del-n') {
            $('#txtTitleConfirm').text('Bạn chắc chắn muốn xóa những Nhân viên đã chọn không ?');
        }
        $('.dialog-confirm').show();
    }

    /**
    * Author: NKĐạt
    * Date: 6/10/2020
    * Hiện Dialog Thông Báo
    * @param {string} checkValue
    * */
    showDialogAnnounce(checkValue) {
        self = this;
        $('.dialog-modal-announce').show();
        if (checkValue == 'POST' && self.FormMode == 'add') {
            $('#txtTitleAnnounce').text('Thêm thành công!');
        } else if (checkValue == 'POST' && self.FormMode != 'add') {
            $('#txtTitleAnnounce').text('Nhân bản thành công!');
        } else if (checkValue == 'PUT') {
            $('#txtTitleAnnounce').text('Sửa thành công!');
        }
        $('.dialog-announce').show();
    }

    /**
    * Author: NKĐạt
    * Date: 19/10/2020
    * Hiện Dialog Cảnh Báo
    * @param {string} checkValue
    * */
    showDialogWarning(checkValue) {
        self = this;
        self.Dialog = "warning";
        $('.dialog-modal-announce').show();
        if (checkValue == 'none') {
            $('#txtTitleWarning').text('Không có nhân viên với mã tương ứng!');
        } else if (checkValue == 'no-select') {
            $('#txtTitleWarning').text('Bạn chưa chọn nhân viên nào!');
        } else if (checkValue == 'validate') {
            $('#txtTitleWarning').text(self.checkValidate + ' không được bỏ trống!');
        } else if (checkValue == 'checkCode') {
            $('#txtTitleWarning').text('Mã nhân viên trùng với Mã nhân viên của nhân viên: ' + self.checkByCode + ' - ' + self.checkByName);
        } else if (checkValue == 'checkEmail') {
            $('#txtTitleWarning').text('Bạn phải nhập đúng định dạng Email');
        }
        $('.dialog-warning').show();
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * Ẩn Dialog Khi Click
    * */
    hideDialogDetail() {
        $('.dialog-modal').hide();
        $('.dialog').hide();
        $('input').removeClass('required-error');
        $('input').removeClass("title");
        $('input').removeAttr("placeholder");
    }

    hideDialogConfirm() {
        $('.dialog-modal-announce').hide();
        $('.dialog-confirm').hide();
    }

    hideDialogWarning() {
        $('.dialog-modal-announce').hide();
        $('.dialog-warning').hide();
        self.Dialog = null;
    }

    hideDialogAnnounce() {
        $('.dialog-modal-announce').hide();
        $('.dialog-announce').hide();
    }

    /**
    * Author: NKĐạt
    * Date: 2/10/2020
    * Check các thông tin bắt buộc nhập
    * @param {this} sender
    * */
    validateRequired(sender) {
        validData.validateRequired(sender.currentTarget);
    }

    /**
    * Author: NKĐạt
    * Date: 2/10/2020
    * Check các thông tin theo từng dialog
    * */
    validateCustom() {
        return true;
    };

    /**
    * Author: NKĐạt
    * Date: 25/9/2020
    * Select hàng
    * */
    rowOnSelect(event) {

        if (event.ctrlKey) {
            $(this).toggleClass('row-selected');
        }
        else {
            $(this).siblings().removeClass('row-selected');
            $(this).addClass('row-selected');
        }
    }

    /**
    * Author: NKĐạt
    * Date: 28/9/2020
    * Responsive Menu
    * */
    slideOnClick() {
        var x = document.getElementById("menu-id");
        if ($(window).width() <= 768) {
            if (x.className === "menu") {
                x.className = "menu-responsive";
            } else {
                x.className = "menu";
            }
        }
    }

    /**
    * Author: NKĐạt
    * Date: 28/9/2020
    * Responsive Menu Close
    * */
    mainPageOnClick() {
        var x = document.getElementById("menu-id");
        if ($(window).width() <= 768) {
            if (x.className === "menu-responsive") {
                x.className = "menu";
            }
        }
    }

    /**
    * Author: NKĐạt
    * Date: 29/9/2020
    * Return Key Press Tab
    * */
    returnFocus() {
        $('#txtEmployeeCode').focus();
        $('#txtCustomerCode').focus();
    }

    /**
    * Author: NKĐạt
    * Date: 6/10/2020
    * Format Money Keyup
    * */
    formatMoneyKeyup() {
        var value = parseInt(this.value.replaceAll('.', ''));
        this.value = value.formatMoney();
    }

    /**
    * Author: NKĐạt
    * Date: 19/10/2020
    * Phím tắt Close (Button X): ESC
    * */
    keydownclose(event) {
        self = this;
        if (!(event.keyCode == 27) && !(event.keyCode == 19)) return true;
        event.preventDefault();
        if (self.Dialog == null)
            self.closeDialogOnClick();
        self.closeDialogAnnounceOnClick()
    }

    /**
    * Author: NKĐạt
    * Date: 19/10/2020
    * Phím tắt Đóng: Ctrl + Q
    * */
    keydowncancel(event) {
        self = this;
        if (!(event.keyCode == 81 && event.ctrlKey) && !(event.keyCode == 19)) return true;
        event.preventDefault();
        if (self.Dialog == null)
            self.closeDialogOnClick();
        self.closeDialogAnnounceOnClick()
    }

    /**
    * Author: NKĐạt
    * Date: 19/10/2020
    * Phím tắt Cất và Thêm: Ctrl + Shilf + S
    * */
    keydownsaveadd(event) {
        self = this;
        if (self.FormMode != null) {
            if (!(event.ctrlKey && event.shiftKey && event.keyCode == 83) && !(event.keyCode == 19)) return true;
            event.preventDefault();
            self.btnSaveAddOnClick();
        }
    }

    /**
    * Author: NKĐạt
    * Date: 19/10/2020
    * Phím tắt Save dữ liệu: Ctrl + S
    * */
    keydownsave(event) {
        self = this;
        if (self.FormMode != null) {
            if (!(event.ctrlKey && event.keyCode == 83) && !(event.keyCode == 19)) return true;
            event.preventDefault();
            self.btnSaveOnClick();
        }
    }
}


/**
* Author: NKĐạt
* Date: 28/9/2020
* Responesive Menu
* */
function menu_responsive() {
    if ($(window).width() > 768) {
        var x = document.getElementById("menu-id");
        x.className = "menu";
    }
}


