using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Engine.Events;

public class BaseGameUIPanelEquipment : GameUIPanelBase {
    
    public static GameUIPanelEquipment Instance;
		
	public UIImageButton buttonEquipmentPowerups;
	public UIImageButton buttonStatistics;
	public UIImageButton buttonAchievements;
	public UIImageButton buttonCustomize;
	
    public UIImageButton buttonClose;
    
    public static bool isInst {
        get {
            if(Instance != null) {
                return true;
            }
            return false;
        }
    }
    
    public virtual void Awake() {
        
    }
	
	public override void Start() {
		Init();
	}
	
	public override void Init() {
		base.Init();	
	}

    public override void OnEnable() {

        Messenger<string>.AddListener(ButtonEvents.EVENT_BUTTON_CLICK, OnButtonClickEventHandler);

        Messenger<string>.AddListener(
            UIControllerMessages.uiPanelAnimateIn,
            OnUIControllerPanelAnimateIn);

        Messenger<string>.AddListener(
            UIControllerMessages.uiPanelAnimateOut,
            OnUIControllerPanelAnimateOut);

        Messenger<string, string>.AddListener(
            UIControllerMessages.uiPanelAnimateType,
            OnUIControllerPanelAnimateType);
    }

    public override void OnDisable() {

        Messenger<string>.RemoveListener(ButtonEvents.EVENT_BUTTON_CLICK, OnButtonClickEventHandler);

        Messenger<string>.RemoveListener(
            UIControllerMessages.uiPanelAnimateIn,
            OnUIControllerPanelAnimateIn);

        Messenger<string>.RemoveListener(
            UIControllerMessages.uiPanelAnimateOut,
            OnUIControllerPanelAnimateOut);

        Messenger<string, string>.RemoveListener(
            UIControllerMessages.uiPanelAnimateType,
            OnUIControllerPanelAnimateType);
    }

    public override void OnUIControllerPanelAnimateIn(string classNameTo) {
        if(className == classNameTo) {
            AnimateIn();
        }
    }

    public override void OnUIControllerPanelAnimateOut(string classNameTo) {
        if(className == classNameTo) {
            AnimateOut();
        }
    }

    public override void OnUIControllerPanelAnimateType(string classNameTo, string code) {
        if(className == classNameTo) {
           //
        }
    }
		
    public override void OnButtonClickEventHandler(string buttonName) {
		
		if(UIUtil.IsButtonClicked(buttonAchievements, buttonName)) {
			GameUIController.ShowAchievements();
		}
		else if(UIUtil.IsButtonClicked(buttonStatistics, buttonName)) {
			GameUIController.ShowStatistics();
		}
		else if(UIUtil.IsButtonClicked(buttonEquipmentPowerups, buttonName)) {
			GameUIController.ShowProducts();
		}
		else if(UIUtil.IsButtonClicked(buttonCustomize, buttonName)) {
			GameUIController.ShowCustomize();
		}		
    }
    
    public override void HandleShow() {
        base.HandleShow();
        
        buttonDisplayState = UIPanelButtonsDisplayState.None;
        characterDisplayState = UIPanelCharacterDisplayState.CharacterLarge;
        backgroundDisplayState = UIPanelBackgroundDisplayState.PanelBacker;
    }
		
	public override void AnimateIn() {
		
		base.AnimateIn();	
	}
	
	public override void AnimateOut() {
		
		base.AnimateOut();
	}

    public virtual void Update() {

        if(GameConfigs.isGameRunning) {
            return;
        }

        if(!isVisible) {
            return;
        }
    }
	
}
