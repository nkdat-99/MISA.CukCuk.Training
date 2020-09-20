$(document).ready(function () {
    var customerJS = new CustomerJS();
})

class CustomerJS {
    constructor() {
        this.loadData();
        this.initEvents();
    }

    initEvents() {
        $('#btnAdd').click(this.btnAddOnClick.bind(this));
        //$('#btnEdit').click(this.btnEditOnClick.bind(this));
        //$('#btnDelete').click(this.btnDeleteOnClick.bind(this));
        $('#btnClose').click(this.btnCloseOnClick.bind(this));
        //$('#btnSave').click(this.btnSaveOnClick.bind(this));
        $('#btnCancel').click(this.btnCancelOnClick.bind(this));
        $('input[required]').blur(this.checkRequired);
        $("table tbody").on("click", "tr", this.rowOnSelect);
    }

    loadData() {
        $.each(customer, function (index, item) {
            var trHTML = $(`<tr>
            <td>` + item.CustomerCode + `</td>
            <td>` + item.CustomerName + `</td>
            <td>` + item.CustomerCompany + `</td>
            <td>` + item.CustomerTax + `</td>
            <td>` + item.CustomerAddress + `</td>
            <td>` + item.CustomerMobile + `</td>
            <td>` + item.CustomerEmail + `</td>
        </tr>`);
            $('.gird tbody').append(trHTML);
        })
    }

    btnAddOnClick() {
        this.showDialogDetail();
    }

    btnCancelOnClick() {
        this.hideDialogDetail();
    }

    btnCloseOnClick() {
        this.hideDialogDetail();
    }

    showDialogDetail() {
        $('.dialog-modal').show();
        $('.dialog').show();
        $('#txtCustomerCode').focus();
    }

    hideDialogDetail() {
        $('.dialog-modal').hide();
        $('.dialog').hide();
    }

    checkRequired() {
        var value = this.value;
        if (!value) {
            $(this).addClass('required-error');
            $(this).attr("title", "Bạn phải nhập thông tin này")
        } else {
            $(this).removeClass('required-error');
            $(this).removeClass("title");
        }
    }

    rowOnSelect() {
        $(this).siblings().removeClass('row-selected');
        $(this).addClass('row-selected');
    }
}

var customer = [
    {
        CustomerCode: "KH0001",
        CustomerName: "Lại Thị Huyền",
        CustomerCompany: "BKAV",
        CustomerTax: "012345",
        CustomerAddress: "Hà Đông, Hà Nội",
        CustomerMobile: "0359434106",
        CustomerEmail: "huyenlai99@gmail.com"
    },
    {
        CustomerCode: "KH0001",
        CustomerName: "Lại Thị Huyền",
        CustomerCompany: "BKAV",
        CustomerTax: "012345",
        CustomerAddress: "Hà Đông, Hà Nội",
        CustomerMobile: "0359434106",
        CustomerEmail: "huyenlai99@gmail.com"
    },
    {
        CustomerCode: "KH0001",
        CustomerName: "Lại Thị Huyền",
        CustomerCompany: "BKAV",
        CustomerTax: "012345",
        CustomerAddress: "Hà Đông, Hà Nội",
        CustomerMobile: "0359434106",
        CustomerEmail: "huyenlai99@gmail.com"
    }
]