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

// 결재라인 지정 부서정보 가져오기
function GetDepartment() {
    var zNodes = [];
    
    $.ajax({
        url : '/Approval/GetDepartment',
        dataType : 'json',
        success : function(data){
            
            for(var i = 0; i <= data.length - 1; i++){
                    zNodes[i] = {
                    code : data[i].code,
                    name : data[i].name,
                    open : false,
                    children : []
                }
            }
            GetEmployeeList(zNodes);
        },
        error : function(){
            alert("Error");
        }
    });
}

// 결재라인 지정 부서에 소속된 직원 가져오기
function GetEmployeeList(zNodes){
    var zTreeObj;
    var setting = {};
    
    $.ajax({
        url : '/Approval/GetEmployees',
        dataType : 'json',
        success : function(data){
            for(var i = 0; i <= data.length - 1 ; i++){
                for(var p = 0; p <= zNodes.length - 1; p++){

                    if(zNodes[p].code == data[i].departmentCode){
                        zNodes[p].children.push({
                            code : data[i].code,
                            name : data[i].name
                        });
                    }
                }
            }

            zTreeObj = $.fn.zTree.init($('#treeDemo'), setting, zNodes);
        }
    });
}