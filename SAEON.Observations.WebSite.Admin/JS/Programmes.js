﻿function onCommand(e, record) {
    DetailsFormPanel.getForm().reset();
    DetailsFormPanel.getForm().loadRecord(record);
    DetailsFormPanel.getForm().clearInvalid();

    tfCode.rvConfig.remoteValidated = false;
    tfCode.rvConfig.remoteValid = false;

    tfName.rvConfig.remoteValidated = false;
    tfName.rvConfig.remoteValid = false;

    tfDescription.rvConfig.remoteValidated = false;
    tfDescription.rvConfig.remoteValid = false;

    tfCode.markAsValid();
    tfName.markAsValid();
    tfDescription.markAsValid();

    DetailWindow.show()
}

function New() {
    DetailsFormPanel.getForm().reset();
    DetailsFormPanel.getForm().clearInvalid();

    tfCode.rvConfig.remoteValidated = false;
    tfCode.rvConfig.remoteValid = false;

    tfName.rvConfig.remoteValidated = false;
    tfName.rvConfig.remoteValid = false;

    tfDescription.rvConfig.remoteValidated = false;
    tfDescription.rvConfig.remoteValid = false;

    tfCode.markAsValid();
    tfName.markAsValid();
    tfDescription.markAsValid();

    DetailWindow.show();
}

function MasterRowSelect(e, record) {
    if (pnlSouth.isVisible())
        ProjectLinksGrid.getStore().reload();
}

function ClearProjectLinkForm() {
    ProjectLinkFormPanel.getForm().reset();
}

function CloseAvailableProjects() {
    AvailableProjectsGrid.selModel.clearSelections();
}

function OnProjectLinkCommand(e, record) {
    if (e === 'Delete') {
        DirectCall.ConfirmDeleteProjectLink(record.get('Id'), { eventMask: { showMask: true } });
    } else if (e === 'Edit') {
        ProjectLinkFormPanel.getForm().reset();
        ProjectLinkFormPanel.getForm().loadRecord(record);
        ProjectLinkFormPanel.getForm().clearInvalid();
        ProjectLinkWindow.show();
    }
}
