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
    using System.Collections.Generic;
    using System.Linq;
    using Skyline.DataMiner.Core.DataMinerSystem.Common;

    internal class ParameterSetterModel : IParameterSetterModel
    {
        private readonly IDms dms;
        private List<IDmsElement> elements;

        public ParameterSetterModel(IDms dms)
        {
            this.dms = dms;
        }

        public IEnumerable<IDmsElement> Elements => elements ?? (elements = dms.GetElements().ToList());

        public IDmsElement SelectedElement { get; set; }

        public int SelectedParameterId { get; set; }

        public void SetDoubleValue(double? value)
        {
            SelectedElement.GetStandaloneParameter<double?>(SelectedParameterId).SetValue(value);
        }

        public void SetStringValue(string value)
        {
            SelectedElement.GetStandaloneParameter<string>(SelectedParameterId).SetValue(value);
        }
    }
}