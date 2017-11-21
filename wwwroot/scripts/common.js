$(document).ready(function(){
    
    InitSummernote();

    $('#btnSetApprovalLine').click(function(){
        OpenApprovalLine();
    });
    
});

//summernote 초기화
function InitSummernote() {
    $("#summernote").summernote({
        height: 500,
        minHeight: null,
        maxHeight: null,
        focus: true
    });
}

// 결재라인 지정
function OpenApprovalLine() {
    window.open('/Approval/SetApproval','_blank','width=700,height=400,scrollbars=0,resizable=0');
}

