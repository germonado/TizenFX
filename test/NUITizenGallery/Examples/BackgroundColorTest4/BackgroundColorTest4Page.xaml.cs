﻿/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class BackgroundColorTest4Page : View
    {
        private Color btnDefaultBackgroundColor;
        public BackgroundColorTest4Page()
        {
            InitializeComponent();
            btnDefaultBackgroundColor = button.BackgroundColor;
            Subscribe();
        }

        private void Subscribe()
        {
            btnRedLabel.Clicked += OnBtnRedLabelClicked;
            btnDefaultLabel.Clicked += OnBtnDefaultLabelClicked;
            btnBlueButton.Clicked += OnBtnBlueButtonClicked;
            btnDefaultButton.Clicked += OnBtnDefaultButtonClicked;
        }
        private void Unsubscribe()
        {
            btnRedLabel.Clicked -= OnBtnRedLabelClicked;
            btnDefaultLabel.Clicked -= OnBtnDefaultLabelClicked;
            btnBlueButton.Clicked -= OnBtnBlueButtonClicked;
            btnDefaultButton.Clicked -= OnBtnDefaultButtonClicked;
        }

        private void OnBtnRedLabelClicked(object sender, ClickedEventArgs e)
        {
            label.BackgroundColor = Color.Red;
        }

        private void OnBtnDefaultLabelClicked(object sender, ClickedEventArgs e)
        {
            label.ClearBackground();
        }

        private void OnBtnBlueButtonClicked(object sender, ClickedEventArgs e)
        {
            button.BackgroundColor = Color.Blue;
        }
        private void OnBtnDefaultButtonClicked(object sender, ClickedEventArgs e)
        {
            button.BackgroundColor = btnDefaultBackgroundColor;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                Unsubscribe();
                RemoveAllChildren(true);
            }

            base.Dispose(type);
        }

        private void RemoveAllChildren(bool dispose = false)
        {
            RecursiveRemoveChildren(this, dispose);
        }

        private void RecursiveRemoveChildren(View parent, bool dispose)
        {
            if (parent == null)
            {
                return;
            }

            int maxChild = (int)parent.ChildCount;
            for (int i = maxChild - 1; i >= 0; --i)
            {
                View child = parent.GetChildAt((uint)i);
                if (child == null)
                {
                    continue;
                }

                RecursiveRemoveChildren(child, dispose);
                parent.Remove(child);
                if (dispose)
                {
                    child.Dispose();
                }
            }
        }
    }
}
