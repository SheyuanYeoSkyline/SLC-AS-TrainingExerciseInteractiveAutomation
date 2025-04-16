/*
****************************************************************************
*  Copyright (c) 2024,  Skyline Communications NV  All Rights Reserved.    *
****************************************************************************

By using this script, you expressly agree with the usage terms and
conditions set out below.
This script and all related materials are protected by copyrights and
other intellectual property rights that exclusively belong
to Skyline Communications.

A user license granted for this script is strictly for personal use only.
This script may not be used in any way by anyone without the prior
written consent of Skyline Communications. Any sublicensing of this
script is forbidden.

Any modifications to this script by the user are only allowed for
personal use and within the intended purpose of the script,
and will remain the sole responsibility of the user.
Skyline Communications will not be responsible for any damages or
malfunctions whatsoever of the script resulting from a modification
or adaptation by the user.

The content of this script is confidential information.
The user hereby agrees to keep this confidential information strictly
secret and confidential and not to disclose or reveal it, in whole
or in part, directly or indirectly to any person, entity, organization
or administration without the prior written consent of
Skyline Communications.

Any inquiries can be addressed to:

	Skyline Communications NV
	Ambachtenstraat 33
	B-8870 Izegem
	Belgium
	Tel.	: +32 51 31 35 69
	Fax.	: +32 51 31 01 29
	E-mail	: info@skyline.be
	Web		: www.skyline.be
	Contact	: Ben Vandenberghe

****************************************************************************
Revision History:

DATE		VERSION		AUTHOR			COMMENTS

22/01/2024	1.0.0.1		XXX, Skyline	Initial version
****************************************************************************
*/

namespace ParameterSetter
{
    using System;

    internal class ParameterSetterPresenter
    {
        private readonly IParameterSetterModel model;
        private readonly IParameterSetterView view;

        private string stringValue;
        private double doubleValue;

        public ParameterSetterPresenter(IParameterSetterModel model, IParameterSetterView view)
        {
            this.model = model ?? throw new ArgumentException(nameof(model));
            this.view = view ?? throw new ArgumentException(nameof(view));

            view.StringValueTextBox.Changed += OnStringValueTextBoxChanged;
            view.SetStringValueButton.Pressed += OnSetStringValueButtonPressed;
            view.DoubleValueNumeric.Changed += OnDoubleValueNumericChanged;
            view.SetDoubleValueButton.Pressed += OnDoubleValueButtonPressed;
            view.BackButton.Pressed += OnBackButtonPressed;
            view.ExitButton.Pressed += OnExitButtonPressed;
        }

        public event EventHandler<EventArgs> BackButtonPressed;

        public event EventHandler<EventArgs> ExitButtonPressed;

        public void LoadFromModel()
        {
            // Do nothing for now.
        }

        private void OnStringValueTextBoxChanged(object sender, EventArgs e)
        {
            stringValue = view.StringValueTextBox.Text;
        }

        private void OnSetStringValueButtonPressed(object sender, EventArgs e)
        {
            try
            {
                model.SetStringValue(stringValue);
                view.OutputTextBox.Text = $"Successfully set PID {model.SelectedParameterId} to {stringValue}.";
            }
            catch (Exception ex)
            {
                view.OutputTextBox.Text = ex.Message;
            }
        }

        private void OnDoubleValueNumericChanged(object sender, EventArgs e)
        {
            doubleValue = view.DoubleValueNumeric.Value;
        }

        private void OnDoubleValueButtonPressed(object sender, EventArgs e)
        {
            try
            {
                model.SetDoubleValue(doubleValue);
                view.OutputTextBox.Text = $"Successfully set PID {model.SelectedParameterId} to {doubleValue}.";
            }
            catch (Exception ex)
            {
                view.OutputTextBox.Text = ex.Message;
            }
        }

        private void OnBackButtonPressed(object sender, EventArgs e)
        {
            BackButtonPressed?.Invoke(sender, e);
        }

        private void OnExitButtonPressed(object sender, EventArgs e)
        {
            ExitButtonPressed?.Invoke(sender, e);
        }
    }
}