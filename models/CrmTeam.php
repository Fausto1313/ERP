<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "crm_team".
 *
 * @property int $id TRIAL
 * @property int|null $message_main_attachment_id TRIAL
 * @property string $name TRIAL
 * @property int|null $sequence TRIAL
 * @property int|null $active TRIAL
 * @property int|null $company_id TRIAL
 * @property int|null $user_id TRIAL
 * @property int|null $color TRIAL
 * @property int|null $create_uid TRIAL
 * @property string|null $create_date TRIAL
 * @property int|null $write_uid TRIAL
 * @property string|null $write_date TRIAL
 * @property int|null $use_leads TRIAL
 * @property int|null $use_opportunities TRIAL
 * @property int $alias_id TRIAL
 * @property int|null $use_quotations TRIAL
 * @property int|null $invoiced_target TRIAL
 * @property string|null $trial304 TRIAL
 *
 * @property CrmLead[] $crmLeads
 * @property CrmLead2opportunityPartner[] $crmLead2opportunityPartners
 * @property CrmLead2opportunityPartnerMass[] $crmLead2opportunityPartnerMasses
 * @property CrmStage[] $crmStages
 * @property MailAlias $alias
 * @property ResCompany $company
 * @property ResUsers $createU
 * @property IrAttachment $messageMainAttachment
 * @property ResUsers $user
 * @property ResUsers $writeU
 * @property ResPartner[] $resPartners
 * @property ResUsers[] $resUsers
 * @property SaleOrder[] $saleOrders
 */
class CrmTeam extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'crm_team';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['message_main_attachment_id', 'sequence', 'active', 'company_id', 'user_id', 'color', 'create_uid', 'write_uid', 'use_leads', 'use_opportunities', 'alias_id', 'use_quotations', 'invoiced_target'], 'integer'],
            [['name', 'alias_id'], 'required'],
            [['name'], 'string'],
            [['create_date', 'write_date'], 'safe'],
            [['trial304'], 'string', 'max' => 1],
            [['alias_id'], 'exist', 'skipOnError' => true, 'targetClass' => MailAlias::className(), 'targetAttribute' => ['alias_id' => 'id']],
            [['company_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCompany::className(), 'targetAttribute' => ['company_id' => 'id']],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['message_main_attachment_id'], 'exist', 'skipOnError' => true, 'targetClass' => IrAttachment::className(), 'targetAttribute' => ['message_main_attachment_id' => 'id']],
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
            'message_main_attachment_id' => 'Message Main Attachment ID',
            'name' => 'Name',
            'sequence' => 'Sequence',
            'active' => 'Active',
            'company_id' => 'Company ID',
            'user_id' => 'User ID',
            'color' => 'Color',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'use_leads' => 'Use Leads',
            'use_opportunities' => 'Use Opportunities',
            'alias_id' => 'Alias ID',
            'use_quotations' => 'Use Quotations',
            'invoiced_target' => 'Invoiced Target',
            'trial304' => 'Trial304',
        ];
    }

    /**
     * Gets query for [[CrmLeads]].
     *
     * @return \yii\db\ActiveQuery|CrmLeadQuery
     */
    public function getCrmLeads()
    {
        return $this->hasMany(CrmLead::className(), ['team_id' => 'id']);
    }

    /**
     * Gets query for [[CrmLead2opportunityPartners]].
     *
     * @return \yii\db\ActiveQuery|CrmLead2opportunityPartnerQuery
     */
    public function getCrmLead2opportunityPartners()
    {
        return $this->hasMany(CrmLead2opportunityPartner::className(), ['team_id' => 'id']);
    }

    /**
     * Gets query for [[CrmLead2opportunityPartnerMasses]].
     *
     * @return \yii\db\ActiveQuery|CrmLead2opportunityPartnerMassQuery
     */
    public function getCrmLead2opportunityPartnerMasses()
    {
        return $this->hasMany(CrmLead2opportunityPartnerMass::className(), ['team_id' => 'id']);
    }

    /**
     * Gets query for [[CrmStages]].
     *
     * @return \yii\db\ActiveQuery|CrmStageQuery
     */
    public function getCrmStages()
    {
        return $this->hasMany(CrmStage::className(), ['team_id' => 'id']);
    }

    /**
     * Gets query for [[Alias]].
     *
     * @return \yii\db\ActiveQuery|MailAliasQuery
     */
    public function getAlias()
    {
        return $this->hasOne(MailAlias::className(), ['id' => 'alias_id']);
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
     * Gets query for [[CreateU]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
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
     * Gets query for [[ResPartners]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerQuery
     */
    public function getResPartners()
    {
        return $this->hasMany(ResPartner::className(), ['team_id' => 'id']);
    }

    /**
     * Gets query for [[ResUsers]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getResUsers()
    {
        return $this->hasMany(ResUsers::className(), ['sale_team_id' => 'id']);
    }

    /**
     * Gets query for [[SaleOrders]].
     *
     * @return \yii\db\ActiveQuery|SaleOrderQuery
     */
    public function getSaleOrders()
    {
        return $this->hasMany(SaleOrder::className(), ['team_id' => 'id']);
    }

    /**
     * {@inheritdoc}
     * @return CrmTeamQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new CrmTeamQuery(get_called_class());
    }
}
