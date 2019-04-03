<%@ Page Title="Manage Patient" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PatientList.aspx.cs" Inherits="Account_Manage" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>

    </div>

    <div class="row">
        <div class="col-md-12">
            <section id="userForm">
                <asp:PlaceHolder runat="server" ID="setFirName">
                    <p>
                        Enter new Patient
                    </p>
                    <div class="form-horizontal">
                        <hr />
                        <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="firtName" CssClass="col-md-2 control-label">Firt Name</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="firtName" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="firtName"
                                    CssClass="text-danger" ErrorMessage="The FirtName field is required."
                                    Display="Dynamic" ValidationGroup="firtName" />
                                <asp:ModelErrorMessage runat="server" ModelStateKey="firtName" AssociatedControlID="firtName"
                                    CssClass="text-danger" SetFocusOnError="true" />
                            </div>
                        </div>


                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="lastName" CssClass="col-md-2 control-label">Last Name</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="lastName" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="lastName"
                                    CssClass="text-danger" ErrorMessage="The lastName field is required."
                                    Display="Dynamic" ValidationGroup="lastName" />
                                <asp:ModelErrorMessage runat="server" ModelStateKey="lastName" AssociatedControlID="lastName"
                                    CssClass="text-danger" SetFocusOnError="true" />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="phone" CssClass="col-md-2 control-label">Phone</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="phone" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="phone"
                                    CssClass="text-danger" ErrorMessage="The Phone field is required."
                                    Display="Dynamic" ValidationGroup="phone" />
                                <asp:ModelErrorMessage runat="server" ModelStateKey="phone" AssociatedControlID="phone"
                                    CssClass="text-danger" SetFocusOnError="true" />
                            </div>
                        </div>


                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="email" CssClass="col-md-2 control-label">E-mail</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="email" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="email"
                                    CssClass="text-danger" ErrorMessage="The email field is required."
                                    Display="Dynamic" ValidationGroup="email" />
                                <asp:ModelErrorMessage runat="server" ModelStateKey="email" AssociatedControlID="email"
                                    CssClass="text-danger" SetFocusOnError="true" />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="gender" CssClass="col-md-2 control-label">Gender</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="gender" CssClass="form-control" />

                                <asp:RequiredFieldValidator runat="server" ControlToValidate="gender"
                                    CssClass="text-danger" ErrorMessage="The gender field is required."
                                    Display="Dynamic" ValidationGroup="gender" />
                                <asp:ModelErrorMessage runat="server" ModelStateKey="gender" AssociatedControlID="gender"
                                    CssClass="text-danger" SetFocusOnError="true" />
                            </div>
                        </div>


                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="note" CssClass="col-md-2 control-label">note</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="note" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="note"
                                    CssClass="text-danger" ErrorMessage="The note field is required."
                                    Display="Dynamic" ValidationGroup="note" />
                                <asp:ModelErrorMessage runat="server" ModelStateKey="note" AssociatedControlID="note"
                                    CssClass="text-danger" SetFocusOnError="true" />
                            </div>

                            <div class="col-md-10">
                                <asp:TextBox Visible="false" runat="server" ID="Identifiable" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Identifiable"
                                    Display="Dynamic" ValidationGroup="Identifiable" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" ID="btnAdd" Text="Create Patient"
                                    OnClick="CrudPatient_Click" CssClass="btn btn-success" />
                            </div>
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" ID="btnUpdate" Text="Update Patient"
                                    OnClick="UpdatePatient" CssClass="btn btn-default" />
                            </div>
                        </div>
                    </div>
                </asp:PlaceHolder>

            </section>

            <section id="externalLoginsForm">

                <asp:ListView runat="server"
                    ItemType="Patient"
                    Visible="<%# Show %>"
                    SelectMethod="LoadPatientOk" UpdateMethod="LoadEdit" DeleteMethod="Remove" DataKeyNames="Identifiable">

                    <LayoutTemplate>
                        <h4>Patients List</h4>
                        <table class="table">
                            <tbody>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </tbody>
                        </table>

                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#: Item.FirtName %></td>
                            <td><%#: Item.LastName %></td>
                            <td><%#: Item.Email %></td>
                            <td>
                                <asp:Button runat="server" Text="Edit" CommandName="Update" CausesValidation="false"
                                    ToolTip='<%# "Update this " + Item.FirtName  %>'
                                    Visible="<%# Show %>" CssClass="btn btn-info" />
                                <asp:Button runat="server" Text="Remove" CommandName="Delete" CausesValidation="false"
                                    ToolTip='<%# "Remove this " + Item.FirtName %>'
                                    Visible="<%# Show %>" CssClass="btn btn-danger" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>

            </section>

        </div>
    </div>

</asp:Content>
