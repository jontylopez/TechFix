﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace TechFix.localhostSupAction {
    using System.Diagnostics;
    using System;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System.Web.Services;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SupplierActionServiceSoap", Namespace="http://tempuri.org/")]
    public partial class SupplierActionService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback InsertSupplierActionOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateSupplierActionOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetRequestByUserIDOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SupplierActionService() {
            this.Url = global::TechFix.Properties.Settings.Default.TechFix_localhostSupAction_SupplierActionService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event InsertSupplierActionCompletedEventHandler InsertSupplierActionCompleted;
        
        /// <remarks/>
        public event UpdateSupplierActionCompletedEventHandler UpdateSupplierActionCompleted;
        
        /// <remarks/>
        public event GetRequestByUserIDCompletedEventHandler GetRequestByUserIDCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/InsertSupplierAction", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int InsertSupplierAction([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] System.Nullable<int> supplierID, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] System.Nullable<int> requestID, string actionStatus) {
            object[] results = this.Invoke("InsertSupplierAction", new object[] {
                        supplierID,
                        requestID,
                        actionStatus});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void InsertSupplierActionAsync(System.Nullable<int> supplierID, System.Nullable<int> requestID, string actionStatus) {
            this.InsertSupplierActionAsync(supplierID, requestID, actionStatus, null);
        }
        
        /// <remarks/>
        public void InsertSupplierActionAsync(System.Nullable<int> supplierID, System.Nullable<int> requestID, string actionStatus, object userState) {
            if ((this.InsertSupplierActionOperationCompleted == null)) {
                this.InsertSupplierActionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnInsertSupplierActionOperationCompleted);
            }
            this.InvokeAsync("InsertSupplierAction", new object[] {
                        supplierID,
                        requestID,
                        actionStatus}, this.InsertSupplierActionOperationCompleted, userState);
        }
        
        private void OnInsertSupplierActionOperationCompleted(object arg) {
            if ((this.InsertSupplierActionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.InsertSupplierActionCompleted(this, new InsertSupplierActionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UpdateSupplierAction", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int UpdateSupplierAction(int actionID, string actionStatus) {
            object[] results = this.Invoke("UpdateSupplierAction", new object[] {
                        actionID,
                        actionStatus});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateSupplierActionAsync(int actionID, string actionStatus) {
            this.UpdateSupplierActionAsync(actionID, actionStatus, null);
        }
        
        /// <remarks/>
        public void UpdateSupplierActionAsync(int actionID, string actionStatus, object userState) {
            if ((this.UpdateSupplierActionOperationCompleted == null)) {
                this.UpdateSupplierActionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateSupplierActionOperationCompleted);
            }
            this.InvokeAsync("UpdateSupplierAction", new object[] {
                        actionID,
                        actionStatus}, this.UpdateSupplierActionOperationCompleted, userState);
        }
        
        private void OnUpdateSupplierActionOperationCompleted(object arg) {
            if ((this.UpdateSupplierActionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateSupplierActionCompleted(this, new UpdateSupplierActionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetRequestByUserID", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetRequestByUserID(int supplierID) {
            object[] results = this.Invoke("GetRequestByUserID", new object[] {
                        supplierID});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetRequestByUserIDAsync(int supplierID) {
            this.GetRequestByUserIDAsync(supplierID, null);
        }
        
        /// <remarks/>
        public void GetRequestByUserIDAsync(int supplierID, object userState) {
            if ((this.GetRequestByUserIDOperationCompleted == null)) {
                this.GetRequestByUserIDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRequestByUserIDOperationCompleted);
            }
            this.InvokeAsync("GetRequestByUserID", new object[] {
                        supplierID}, this.GetRequestByUserIDOperationCompleted, userState);
        }
        
        private void OnGetRequestByUserIDOperationCompleted(object arg) {
            if ((this.GetRequestByUserIDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRequestByUserIDCompleted(this, new GetRequestByUserIDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void InsertSupplierActionCompletedEventHandler(object sender, InsertSupplierActionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class InsertSupplierActionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal InsertSupplierActionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void UpdateSupplierActionCompletedEventHandler(object sender, UpdateSupplierActionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateSupplierActionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateSupplierActionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void GetRequestByUserIDCompletedEventHandler(object sender, GetRequestByUserIDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRequestByUserIDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRequestByUserIDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591