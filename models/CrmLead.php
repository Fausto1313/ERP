<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "crm_lead".
 *
 * @property int $id TRIAL
 * @property string|null $email_cc TRIAL
 * @property int|null $message_main_attachment_id TRIAL
 * @property int|null $message_bounce TRIAL
 * @property string|null $email_normalized TRIAL
 * @property int|null $campaign_id TRIAL
 * @property int|null $source_id TRIAL
 * @property int|null $medium_id TRIAL
 * @property string $name TRIAL
 * @property int|null $partner_id TRIAL
 * @property int|null $active TRIAL
 * @property string|null $date_action_last TRIAL
 * @property string|null $email_from TRIAL
 * @property string|null $website TRIAL
 * @property int|null $team_id TRIAL
 * @property string|null $description TRIAL
 * @property string|null $contact_name TRIAL
 * @property string|null $partner_name TRIAL
 * @property string $type TRIAL
 * @property string|null $priority TRIAL
 * @property string|null $date_closed TRIAL
 * @property int|null $stage_id TRIAL
 * @property int|null $user_id TRIAL
 * @property string|null $referred TRIAL
 * @property string|null $date_open TRIAL
 * @property float|null $day_open TRIAL
 * @property float|null $day_close TRIAL
 * @property string|null $date_last_stage_update TRIAL
 * @property string|null $date_conversion TRIAL
 * @property float|null $probability TRIAL
 * @property float|null $automated_probability TRIAL
 * @property string|null $phone_state TRIAL
 * @property string|null $email_state TRIAL
 * @property float|null $planned_revenue TRIAL
 * @property float|null $expected_revenue TRIAL
 * @property string|null $date_deadline TRIAL
 * @property int|null $color TRIAL
 * @property string|null $street TRIAL
 * @property string|null $street2 TRIAL
 * @property string|null $zip TRIAL
 * @property string|null $city TRIAL
 * @property int|null $state_id TRIAL
 * @property int|null $country_id TRIAL
 * @property int|null $lang_id TRIAL
 * @property string|null $phone TRIAL
 * @property string|null $mobile TRIAL
 * @property string|null $function TRIAL
 * @property int|null $title TRIAL
 * @property int|null $company_id TRIAL
 * @property int|null $lost_reason TRIAL
 * @property int|null $create_uid TRIAL
 * @property string|null $create_date TRIAL
 * @property int|null $write_uid TRIAL
 * @property string|null $write_date TRIAL
 * @property string|null $trial242 TRIAL
 *
 * @property UtmCampaign $campaign
 * @property ResCompany $company
 * @property ResCountry $country
 * @property ResUsers $createU
 * @property ResLang $lang
 * @property CrmLostReason $lostReason
 * @property UtmMedium $medium
 * @property IrAttachment $messageMainAttachment
 * @property ResPartner $partner
 * @property UtmSource $source
 * @property CrmStage $stage
 * @property ResCountryState $state
 * @property CrmTeam $team
 * @property ResPartnerTitle $title0
 * @property ResUsers $user
 * @property ResUsers $writeU
 * @property SaleOrder[] $saleOrders
 */
class CrmLead extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'crm_lead';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['email_cc', 'email_normalized', 'name', 'email_from', 'website', 'description', 'contact_name', 'partner_name', 'type', 'priority', 'referred', 'phone_state', 'email_state', 'street', 'street2', 'zip', 'city', 'phone', 'mobile', 'function'], 'string'],
            [['message_main_attachment_id', 'message_bounce', 'campaign_id', 'source_id', 'medium_id', 'partner_id', 'active', 'team_id', 'stage_id', 'user_id', 'color', 'state_id', 'country_id', 'lang_id', 'title', 'company_id', 'lost_reason', 'create_uid', 'write_uid'], 'integer'],
            [['name', 'type'], 'required'],
            [['date_action_last', 'date_closed', 'date_open', 'date_last_stage_update', 'date_conversion', 'date_deadline', 'create_date', 'write_date'], 'safe'],
            [['day_open', 'day_close', 'probability', 'automated_probability', 'planned_revenue', 'expected_revenue'], 'number'],
            [['trial242'], 'string', 'max' => 1],
            [['campaign_id'], 'exist', 'skipOnError' => true, 'targetClass' => UtmCampaign::className(), 'targetAttribute' => ['campaign_id' => 'id']],
            [['company_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCompany::className(), 'targetAttribute' => ['company_id' => 'id']],
            [['country_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCountry::className(), 'targetAttribute' => ['country_id' => 'id']],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['lang_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResLang::className(), 'targetAttribute' => ['lang_id' => 'id']],
            [['lost_reason'], 'exist', 'skipOnError' => true, 'targetClass' => CrmLostReason::className(), 'targetAttribute' => ['lost_reason' => 'id']],
            [['medium_id'], 'exist', 'skipOnError' => true, 'targetClass' => UtmMedium::className(), 'targetAttribute' => ['medium_id' => 'id']],
            [['message_main_attachment_id'], 'exist', 'skipOnError' => true, 'targetClass' => IrAttachment::className(), 'targetAttribute' => ['message_main_attachment_id' => 'id']],
            [['partner_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResPartner::className(), 'targetAttribute' => ['partner_id' => 'id']],
            [['source_id'], 'exist', 'skipOnError' => true, 'targetClass' => UtmSource::className(), 'targetAttribute' => ['source_id' => 'id']],
            [['stage_id'], 'exist', 'skipOnError' => true, 'targetClass' => CrmStage::className(), 'targetAttribute' => ['stage_id' => 'id']],
            [['state_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCountryState::className(), 'targetAttribute' => ['state_id' => 'id']],
            [['team_id'], 'exist', 'skipOnError' => true, 'targetClass' => CrmTeam::className(), 'targetAttribute' => ['team_id' => 'id']],
            [['title'], 'exist', 'skipOnError' => true, 'targetClass' => ResPartnerTitle::className(), 'targetAttribute' => ['title' => 'id']],
            [['user_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['user_id' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    /**
     * {@inheritdoc}
     */
    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'email_cc' => 'Email Cc',
            'message_main_attachment_id' => 'Message Main Attachment ID',
            'message_bounce' => 'Message Bounce',
            'email_normalized' => 'Email Normalized',
            'campaign_id' => 'Campaign ID',
            'source_id' => 'Source ID',
            'medium_id' => 'Medium ID',
            'name' => 'Name',
            'partner_id' => 'Partner ID',
            'active' => 'Active',
            'date_action_last' => 'Date Action Last',
            'email_from' => 'Email From',
            'website' => 'Website',
            'team_id' => 'Team ID',
            'description' => 'Description',
            'contact_name' => 'Contact Name',
            'partner_name' => 'Partner Name',
            'type' => 'Type',
            'priority' => 'Priority',
            'date_closed' => 'Date Closed',
            'stage_id' => 'Stage ID',
            'user_id' => 'User ID',
            'referred' => 'Referred',
            'date_open' => 'Date Open',
            'day_open' => 'Day Open',
            'day_close' => 'Day Close',
            'date_last_stage_update' => 'Date Last Stage Update',
            'date_conversion' => 'Date Conversion',
            'probability' => 'Probability',
            'automated_probability' => 'Automated Probability',
            'phone_state' => 'Phone State',
            'email_state' => 'Email State',
            'planned_revenue' => 'Planned Revenue',
            'expected_revenue' => 'Expected Revenue',
            'date_deadline' => 'Date Deadline',
            'color' => 'Color',
            'street' => 'Street',
            'street2' => 'Street2',
            'zip' => 'Zip',
            'city' => 'City',
            'state_id' => 'State ID',
            'country_id' => 'Country ID',
            'lang_id' => 'Lang ID',
            'phone' => 'Phone',
            'mobile' => 'Mobile',
            'function' => 'Function',
            'title' => 'Title',
            'company_id' => 'Company ID',
            'lost_reason' => 'Lost Reason',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'trial242' => 'Trial242',
        ];
    }

    /**
     * Gets query for [[Campaign]].
     *
     * @return \yii\db\ActiveQuery|UtmCampaignQuery
     */
    public function getCampaign()
    {
        return $this->hasOne(UtmCampaign::className(), ['id' => 'campaign_id']);
    }

    /**
     * Gets query for [[Company]].
     *
     * @return \yii\db\ActiveQuery|ResCompanyQuery
     */
    public function getCompany()
    {
        return $this->hasOne(ResCompany::className(), ['id' => 'company_id']);
    }

    /**
     * Gets query for [[Country]].
     *
     * @return \yii\db\ActiveQuery|ResCountryQuery
     */
    public function getCountry()
    {
        return $this->hasOne(ResCountry::className(), ['id' => 'country_id']);
    }

    /**
     * Gets query for [[CreateU]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    /**
     * Gets query for [[Lang]].
     *
     * @return \yii\db\ActiveQuery|ResLangQuery
     */
    public function getLang()
    {
        return $this->hasOne(ResLang::className(), ['id' => 'lang_id']);
    }

    /**
     * Gets query for [[LostReason]].
     *
     * @return \yii\db\ActiveQuery|CrmLostReasonQuery
     */
    public function getLostReason()
    {
        return $this->hasOne(CrmLostReason::className(), ['id' => 'lost_reason']);
    }

    /**
     * Gets query for [[Medium]].
     *
     * @return \yii\db\ActiveQuery|UtmMediumQuery
     */
    public function getMedium()
    {
        return $this->hasOne(UtmMedium::className(), ['id' => 'medium_id']);
    }

    /**
     * Gets query for [[MessageMainAttachment]].
     *
     * @return \yii\db\ActiveQuery|IrAttachmentQuery
     */
    public function getMessageMainAttachment()
    {
        return $this->hasOne(IrAttachment::className(), ['id' => 'message_main_attachment_id']);
    }

    /**
     * Gets query for [[Partner]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerQuery
     */
    public function getPartner()
    {
        return $this->hasOne(ResPartner::className(), ['id' => 'partner_id']);
    }

    /**
     * Gets query for [[Source]].
     *
     * @return \yii\db\ActiveQuery|UtmSourceQuery
     */
    public function getSource()
    {
        return $this->hasOne(UtmSource::className(), ['id' => 'source_id']);
    }

    /**
     * Gets query for [[Stage]].
     *
     * @return \yii\db\ActiveQuery|CrmStageQuery
     */
    public function getStage()
    {
        return $this->hasOne(CrmStage::className(), ['id' => 'stage_id']);
    }

    /**
     * Gets query for [[State]].
     *
     * @return \yii\db\ActiveQuery|ResCountryStateQuery
     */
    public function getState()
    {
        return $this->hasOne(ResCountryState::className(), ['id' => 'state_id']);
    }

    /**
     * Gets query for [[Team]].
     *
     * @return \yii\db\ActiveQuery|CrmTeamQuery
     */
    public function getTeam()
    {
        return $this->hasOne(CrmTeam::className(), ['id' => 'team_id']);
    }

    /**
     * Gets query for [[Title0]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerTitleQuery
     */
    public function getTitle0()
    {
        return $this->hasOne(ResPartnerTitle::className(), ['id' => 'title']);
    }

    /**
     * Gets query for [[User]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getUser()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'user_id']);
    }

    /**
     * Gets query for [[WriteU]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    /**
     * Gets query for [[SaleOrders]].
     *
     * @return \yii\db\ActiveQuery|SaleOrderQuery
     */
    public function getSaleOrders()
    {
        return $this->hasMany(SaleOrder::className(), ['opportunity_id' => 'id']);
    }

    /**
     * {@inheritdoc}
     * @return CrmLeadQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new CrmLeadQuery(get_called_class());
    }
}
