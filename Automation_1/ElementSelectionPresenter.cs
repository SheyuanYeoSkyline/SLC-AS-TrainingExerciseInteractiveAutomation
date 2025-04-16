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
    using System.Collections.Generic;
    using System.Linq;
    using Skyline.DataMiner.Core.DataMinerSystem.Common;

    internal class ElementSelectionPresenter
    {
        private readonly IParameterSetterModel model;
        private readonly IElementSelectionView view;

        private Dictionary<string, IDmsElement> elementsByName;
        private string selectedElementName;

        public ElementSelectionPresenter(IParameterSetterModel model, IElementSelectionView view)
        {
            this.model = model ?? throw new ArgumentException(nameof(model));
            this.view = view ?? throw new ArgumentException(nameof(view));

            view.ElementDropDown.Changed += OnElementDropdownChanged;
            view.CancelButton.Pressed += OnCancelButtonPressed;
            view.ContinueButton.Pressed += OnContinueButtonPressed;
        }

        public event EventHandler<EventArgs> CancelButtonPressed;

        public event EventHandler<EventArgs> ContinueButtonPressed;

        public void LoadFromModel()
        {
            elementsByName = model.Elements.ToDictionary(x => x.Name);
            view.ElementDropDown.Options = elementsByName.Keys;
            selectedElementName = model.SelectedElement?.Name ?? elementsByName.Keys.First();
            view.ElementDropDown.Selected = selectedElementName;
        }

        private void SaveToModel()
        {
            model.SelectedElement = elementsByName[selectedElementName];
        }

        private void OnElementDropdownChanged(object sender, EventArgs e)
        {
            selectedElementName = view.ElementDropDown.Selected;
        }

        private void OnCancelButtonPressed(object sender, EventArgs e)
        {
            SaveToModel();
            CancelButtonPressed?.Invoke(sender, e);
        }

        private void OnContinueButtonPressed(object sender, EventArgs e)
        {
            SaveToModel();
            ContinueButtonPressed?.Invoke(sender, e);
        }
    }
}