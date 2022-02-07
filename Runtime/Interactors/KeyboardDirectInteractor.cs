/* MIT License

Copyright (c) 2020 - 21 Runette Software

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice (and subsidiary notices) shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE. */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.UI;

namespace VrKeyboard
{

    public class KeyboardDirectInteractor : KeyboardInteractor
    {
        private Collider m_collider;

        void Start()
        {
            base.Start();
            m_collider = GetComponent<Collider>();
        }

        public override void UpdateUIModel(ref TrackedDeviceModel model)
        {
            // Start is called before the first frame update
            if (!isActiveAndEnabled)
                return;

            Bounds bounds = m_collider.bounds;
            Vector3 center = bounds.center;
            Vector3 extents = bounds.extents;
 
            model.position = center;
            model.orientation = transform.rotation;

            model.select = isUISelectActive;

            List<Vector3> raycastPoints = model.raycastPoints;
            raycastPoints.Clear();


            raycastPoints.Add(new Vector3(center.x, center.y, center.z - extents.z));
            raycastPoints.Add(new Vector3(center.x, center.y, center.z + extents.z));
        }
    }
}
