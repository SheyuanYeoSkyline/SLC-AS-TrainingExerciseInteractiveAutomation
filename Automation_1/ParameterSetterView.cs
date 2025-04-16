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
    using Skyline.DataMiner.Automation;
    using Skyline.DataMiner.Utils.InteractiveAutomationScript;

    internal class ParameterSetterView : Dialog, IParameterSetterView
    {
        public ParameterSetterView(IEngine engine) : base(engine)
        {
            Title = "Set Parameter Value";

            var stringLabel = new Label("String Value");
            var doubleLabel = new Label("Double Value");

            StringValueTextBox = new TextBox();
            DoubleValueNumeric = new Numeric();
            SetStringValueButton = new Button("Set String");
            SetDoubleValueButton = new Button("Set Double");
            OutputTextBox = new TextBox();
            BackButton = new Button("Back...");
            ExitButton = new Button("Exit");

            DoubleValueNumeric.StepSize = 0.01;
            OutputTextBox.IsEnabled = false;

            AddWidget(stringLabel, 2, 1, 1, 1);
            AddWidget(StringValueTextBox, 2, 2, 1, 1);
            AddWidget(SetStringValueButton, 2, 3, 1, 1);

            AddWidget(doubleLabel, 3, 1, 1, 1);
            AddWidget(DoubleValueNumeric, 3, 2, 1, 1);
            AddWidget(SetDoubleValueButton, 3, 3, 1, 1);

            AddWidget(OutputTextBox, 4, 1, 1, 3);
            AddWidget(BackButton, 5, 1, 1, 1);
            AddWidget(ExitButton, 5, 3, 1, 1);
        }

        public TextBox StringValueTextBox { get; }

        public Numeric DoubleValueNumeric { get; }

        public Button SetStringValueButton { get; }

        public Button SetDoubleValueButton { get; }

        public TextBox OutputTextBox { get; }

        public Button BackButton { get; }

        public Button ExitButton { get; }
    }
}