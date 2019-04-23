/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="../bootstrap.min.js" />
/// <reference path="../bootstrap-treeview.min.js" />


var tree = [
{
    text: "Parent 1",
    nodes: [
      {
          text: "Child 1",
          nodes: [
            {
                text: "Grandchild "
            },
            {
                text: "Grandchild 2"
            }
          ]
      },
      {
          text: "Child 2"
      }
    ]
},
{
    text: "Parent 2"
},
{
    text: "Parent 3"
},
{
    text: "Parent 4"
},
{
    text: "Parent 5"
}
];

function setFuncUrl(url) {

    if (PAGE_CHANGE_ACTION) {
        PAGE_CHANGE_ACTION(url);
    }
    $("#ife").attr('src', url);
}

$(function () {

    function getSelectedTreenode() {

        var selectedNodes = $('#tree').treeview('getSelected');
        if (!selectedNodes || selectedNodes.length == 0) {
            alert("没有选择任何节点");
            return null;
        }
        return selectedNodes[0];
    }

    //https://github.com/jonmiles/bootstrap-treeview
    $("#tree").treeview({
        data: eval('(' + $('#tree').attr('data-treedata') + ')'),
        borderColor: null,
        expandIcon: "glyphicon glyphicon-plus",
        emptyIcon: 'glyphicon'
    });

    $("#proj-add").click(function () {
        var node = getSelectedTreenode();
        if (!node) {
            return;
        }
        setFuncUrl('/wr/projectedit?parentID=' + node.id);
    });

    $("#proj-edit").click(function () {
        var node = getSelectedTreenode();
        if (!node) {
            return;
        }
        setFuncUrl('/wr/projectedit?ID=' + node.id);
    });
});